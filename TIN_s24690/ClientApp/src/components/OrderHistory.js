import React, {useEffect, useState} from "react";
import NavBar from "./NavBar";
import axios from "axios";


export default function OrderHistory({english, setEnglish, user, setUser}){
    const [zamowienia, setZamowienia] = useState([]);
    const [zamowieniaSzczegoly, setZamowieniaSzczegoly] = useState([]);
    const [osoba, setOsoba] = useState(null);
    const [empty, setEmpty] = useState(false);
    const [detailsVisable, setDetailsVisable] = useState(false);
    
    const [szczegoly, setSzczegoly] = useState("SZCZEGÓŁY");
    
    useEffect(() => {
        if(english){
            setSzczegoly("DETAILS");
        }else{
            setSzczegoly("SZCZEGÓŁY");
        }
    })

    const [currentPage, setCurrentPage] = useState(1);
    const [itemsPerPage] = useState(3);
    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;

    const currentItems = zamowieniaSzczegoly.slice(indexOfFirstItem, indexOfLastItem);

    const pageNumbers = [];
    for (let i = 1; i <= Math.ceil(zamowieniaSzczegoly.length / itemsPerPage); i++) {
        pageNumbers.push(i);
    }

    const renderPageNumber = pageNumbers.map(number => (
        <button key={number} onClick={() => setCurrentPage(number)}>
            {number}
        </button>
    ));
    
    const handleClickDetails = () => {
        if(!detailsVisable){
            setDetailsVisable(true);
        }else{
            setDetailsVisable(false);
        }
    }
    
    
    useEffect(() => {
        axios.get(`/Osoba/idUzytkownik/${user.idUzytkownik}`)
            .then(response => {
                setOsoba(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
    }, []);
    
    useEffect(() => {
        if (osoba !== null) {
            axios.get(`/Zamowienie/Osoba/${osoba.idOsoba}`)
                .then(response => {
                    setZamowienia(response.data);
                    getDetails(response.data).then(detail => {
                        setZamowieniaSzczegoly(detail);
                    });
                })
                .catch(error => {
                    console.error('Wystąpił błąd', error);
                });
        }
    }, [osoba]);

    useEffect(() => {
        console.log(zamowieniaSzczegoly);
        if(zamowieniaSzczegoly.length === 0){
            setEmpty(true);
        }else{
            setEmpty(false);
        }
    }, [zamowieniaSzczegoly]);

    const getDetails = async () => {
        try {
            return await Promise.all(zamowienia.map(async zamowienie => {
                const idZamowienia = zamowienie.idZamowienie;
                
                const [pizzeResponse, napojeResponse, dodatkiResponse] = await Promise.all([
                    axios.get(`/Zamowienie/ZamowieniePizza/${idZamowienia}`),
                    axios.get(`/Zamowienie/ZamowienieNapoj/${idZamowienia}`),
                    axios.get(`/Zamowienie/ZamowienieDodatek/${idZamowienia}`)
                ]);
                return [
                    zamowienie,
                    pizzeResponse.data,
                    napojeResponse.data,
                    dodatkiResponse.data
                ];
            }));
        } catch (error) {
            console.error('Wystąpił błąd podczas pobierania szczegółów zamówień', error);
        }
    };
    const formatElements = (elementy) =>
        elementy.map(el => `x${el.ilosc} ${el.nazwa} - ${el.cena} zł`).join(", ");
    
    return(
        <div className={"homeContainer"}>
            <NavBar user={user} setUser={setUser} english={english} setEnglish={setEnglish}/>
            <div className={"menuContainer"}>
                <div className={"menuBox"}>
                    <div className={"history"}>
                        <div className={"wrap"}>
                            {zamowieniaSzczegoly.map((zamowienie, index) => (
                                <div key={index} className="zamowienie-container">
                                    <div className="zamowienie-info">
                                        <h1>Data: {zamowienie[0].dataZlozenia}</h1>
                                        <p>Status: {zamowienie[0].status}</p>
                                        {detailsVisable && (
                                            <div>
                                                <p>Pizze: {formatElements(zamowienie[1])}</p>
                                                <p>Napoje: {formatElements(zamowienie[2])}</p>
                                                <p>Dodatki: {formatElements(zamowienie[3])}</p>
                                            </div>
                                        )}
                                    </div>
                                </div>
                            ))}
                            <div className={"box"}>
                                <div className="zamowienie-szczegoly">
                                    <button onClick={handleClickDetails}>{szczegoly}</button>
                                </div>
                                <div className="pagination">{renderPageNumber}</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
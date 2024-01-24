import React, {useEffect, useState} from "react";
import axios from "axios";
import NavBar from "./NavBar";
import RegNavBar from "./RegNavBar";

export default function AdresNavBar({basket, setBasket, english, setEnglish, setIdAdres, idAdres, user, setUser}){
    const [formData, setFormData] = useState({
        kraj: '',
        miasto: '',
        ulica: '',
        nrUlicy: '',
        nrMieszkania: ''
    });
    const [kraj, setKraj] = useState("Kraj");
    const [miasto, setMiasto] = useState("Miasto");
    const [ulica, setUlica] = useState("Ulica");
    const [nrUlicy, setNrUlicy] = useState("Numer Domu");
    const [nrMieszkania, setNrMieszkania] = useState("Numer Mieszkania");
    const [wyslij, setWyslij] = useState("WYŚLIJ");
    const [showOrder, setShowOrder] = useState(true);

    useEffect(() => {
        if(english){
            setKraj("Country");
            setMiasto("Town");
            setUlica("Street");
            setNrUlicy("Street number");
            setNrMieszkania("Flat number");
            setWyslij("SEND");
        }else{
            setKraj("Kraj");
            setMiasto("Miasto");
            setUlica("Ulica");
            setNrUlicy("Numer Domu");
            setNrMieszkania("Numer Mieszkania");
            setWyslij("WYŚLIJ");
        }
    })

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: name === 'nrUlicy' || name === 'nrMieszkania' ? parseInt(value) : value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.post('/Adres', formData)
            .then(response => {
                console.log(response);
                setIdAdres(response.data);
                setShowOrder(false);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
    };

    return (
        <div className={"homeContainer"}>
            <NavBar english={english} setEnglish={setEnglish}/>
            <div className={"menuContainer"}>
                <div className={"menuBox"}>
                    <div className={"food"}>
                        {showOrder && (<form onSubmit={handleSubmit}>
                                <input
                                    type="text"
                                    name="kraj"
                                    value={formData.kraj}
                                    onChange={handleInputChange}
                                    placeholder={kraj}
                                />
                                <input
                                    type="text"
                                    name="miasto"
                                    value={formData.miasto}
                                    onChange={handleInputChange}
                                    placeholder={miasto}
                                />
                                <input
                                    type="text"
                                    name="ulica"
                                    value={formData.ulica}
                                    onChange={handleInputChange}
                                    placeholder={ulica}
                                />
                                <input
                                    type="number"
                                    name="nrUlicy"
                                    value={formData.nrUlicy}
                                    onChange={handleInputChange}
                                    placeholder={nrUlicy}
                                />
                                <input
                                    type="number"
                                    name="nrMieszkania"
                                    value={formData.nrMieszkania}
                                    onChange={handleInputChange}
                                    placeholder={nrMieszkania}
                                />
                                <button type="submit">{wyslij}</button>
                            </form>
                        )}
                        {!showOrder && (
                            <RegNavBar english={english} basket={basket} setBasket={setBasket} idAdres={idAdres} user={user}
                                      setUser={setUser}/>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
}
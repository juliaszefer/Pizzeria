import React, {useEffect, useState} from "react";
import axios from "axios";
import {Link, useNavigate} from "react-router-dom";

export default function AddPizza({english}){
    const navigate = useNavigate();
    const [nazwa, setNazwa] = useState("Nazwa po polsku");
    const [cena, setCena] = useState("Cena");
    const [tlumaczenie, setTlumaczenie] = useState("Nazwa po angielsku");
    const [wyslij, setWyslij] = useState("WYŚLIJ");
    const [nowysklad, setNowysklad] = useState("DODAJ NOWY SKŁADNIK");
    const [nazwaSklad, setNazwaSklad] = useState("Nazwa składnika");

    const [idSkladnikLista, setIdSkladnikLista] = useState([]);
    
    const [skladniki, setSkladniki] = useState([]);
    
    const [showAddPizza, setShowAddPizza] = useState(true);
    const [showChooseSkladnik, setChooseSkladnik] = useState(false);
    const [showAddSkladnik, setAddSkladnik] = useState(false);
    
    const [idPizza, setIdPizza] = useState(0);

    const [nazwaSkladnika, setNazwaSkladnika] = useState({
        nazwa: '',
        tlumaczenie: ''
    });
    
    const [formData, setFormData] = useState({
        nazwa: '',
        cena: 0,
        tlumaczenie: ''
    });

    const handleCheckboxChange = (id) => {
        setIdSkladnikLista(prevState => {
            if (prevState.includes(id)) {
                return prevState.filter(skladnikId => skladnikId !== id);
            } else {
                return [...prevState, id];
            }
        });
    };

    useEffect(() => {
        if(english){
            setNazwa("Name in polish");
            setCena("Price");
            setTlumaczenie("Name in english");
            setWyslij("SEND");
            setNowysklad("ADD NEW SIDE DISH");
            setNazwaSklad("Side dish name");
        }else{
            setNazwa("Nazwa po polsku");
            setCena("Cena");
            setTlumaczenie("Nazwa po angielsku");
            setWyslij("WYŚLIJ");
            setNowysklad("DODAJ NOWY SKŁADNIK");
            setNazwaSklad("Nazwa składnika");
        }
    });
    
    useEffect(() => {
        axios.get('/Skladnik')
            .then(response => {
                setSkladniki(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
    }, []);
    const handleInputChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleInputChangeSkladnik = (e) => {
        setNazwaSkladnika(prevState => ({
            ...prevState,
            [e.target.name]: e.target.value
        }));
    };

    const handleSubmitSkladnik = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('/Skladnik', nazwaSkladnika);
            console.log(response.data);
            
            const skladnikDto = {
                idPizza: idPizza,
                idSkladnik: response.data
            }
            const resp = await axios.post('/Pizza/PizzaSkladnik', skladnikDto);
            console.log(resp)
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania formularza', error);
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('/Pizza', formData);
            console.log(response);
            setIdPizza(response.data);
            setShowAddPizza(false);
            setChooseSkladnik(true);
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania formularza', error);
        }
    };
    
    const handleClickAdd = async (e) => {
        e.preventDefault();
        setChooseSkladnik(false);
        setAddSkladnik(true);

        try {
            for (const idSkladnik of idSkladnikLista) {
                await axios.post('/Pizza/PizzaSkladnik', {
                    idPizza: idPizza,
                    idSkladnik: idSkladnik
                });
            }
            console.log("gotowe");
        } catch (error) {
            console.error('Wystąpił błąd', error);
        }
    }

    return (
        <div>
            {showAddPizza && (
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>{nazwa}:</label>
                        <input
                            type="text"
                            name="nazwa"
                            value={formData.nazwa}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div>
                        <label>{cena}:</label>
                        <input
                            type="number"
                            name="cena"
                            value={formData.cena}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div>
                        <label>{tlumaczenie}:</label>
                        <input
                            type="text"
                            name="tlumaczenie"
                            value={formData.tlumaczenie}
                            onChange={handleInputChange}
                        />
                    </div>
                    <button type="submit">{wyslij}</button>
                </form>
            )}
            {showChooseSkladnik && (
                <div>
                    {skladniki.map(skladnik => (
                        <div key={skladnik.idSkladnik}>
                            <input
                                type="checkbox"
                                id={`skladnik-${skladnik.idSkladnik}`}
                                onChange={() => handleCheckboxChange(skladnik.idSkladnik)}
                                checked={idSkladnikLista.includes(skladnik.idSkladnik)}
                            />
                            <label>{skladnik.nazwa}</label>
                        </div>
                    ))}
                    <button onClick={handleClickAdd}>{nowysklad}</button>
                </div>
            )}
            {showAddSkladnik && (
                <form onSubmit={handleSubmitSkladnik}>
                    <div>
                        <label>{nazwaSklad}:</label>
                        <input
                            type="text"
                            name="nazwa"
                            value={nazwaSkladnika.nazwa}
                            onChange={handleInputChangeSkladnik}
                        />
                    </div>
                    <div>
                        <label>{tlumaczenie}:</label>
                        <input
                            type="text"
                            name="tlumaczenie"
                            value={nazwaSkladnika.tlumaczenie}
                            onChange={handleInputChangeSkladnik}
                        />
                    </div>
                    <button type="submit">{wyslij}</button>
                </form>
            )}
            <button><Link to={"/"}>OK</Link></button>
        </div>
    );
}
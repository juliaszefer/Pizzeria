import React, {useEffect, useState} from "react";
import axios from "axios";
import RegUser from "./RegUser";
import RegUserNavBar from "./RegUserNavBar";

export default function RegNavBar({idAdres, basket, setBasket, user, setUser, english}){
    const [idOsoba, setIdOsoba] = useState(0);
    const [imie, setImie] = useState("Imię");
    const [nazwisko, setNazwisko] = useState("Nazwisko");
    const [nrtel, setNrtel] = useState("Numer telefonu");
    const [wyslij, setWyslij] = useState("WYŚLIJ");

    const [showReg, setShowReg] = useState(true);
    const [showRegUser, setShowRegUser] = useState(false);

    useEffect(() => {
        if(english){
            setImie("Name");
            setNazwisko("Surname");
            setNrtel("Phone number");
            setWyslij("SEND");
        }else{
            setImie("Imię");
            setNazwisko("Nazwisko");
            setNrtel("Numer telefonu");
            setWyslij("WYŚLIJ");
        }
    });

    const [formData, setFormData] = useState({
        imie: '',
        nazwisko: '',
        nrTelefonu: '',
        email: '',
        idAdres: idAdres
    });

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await axios.post('/Osoba/NewOsobaUzytkownik', formData);
            console.log(response.data);
            setIdOsoba(response.data);
            setShowReg(false);
            setShowRegUser(true);
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania danych', error);
            if(error.code === "ERR_BAD_REQUEST"){
                axios.get(`/Osoba/${formData.email}`)
                    .then(response => {
                        setIdOsoba(response.data.idOsoba);
                        setShowReg(false);
                        setShowRegUser(true);
                    })
                    .catch(error => {
                        console.error('Wystąpił błąd', error);
                    });
            }
        }
    };

    return (
        <div>
            {showReg && (
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="imie"
                        value={formData.imie}
                        onChange={handleInputChange}
                        placeholder={imie}
                    />
                    <input
                        type="text"
                        name="nazwisko"
                        value={formData.nazwisko}
                        onChange={handleInputChange}
                        placeholder={nazwisko}
                    />
                    <input
                        type="text"
                        name="nrTelefonu"
                        value={formData.nrTelefonu}
                        onChange={handleInputChange}
                        placeholder={nrtel}
                    />
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleInputChange}
                        placeholder="Email"
                    />
                    <button type="submit">{wyslij}</button>
                </form>
            )}
            {showRegUser && (
                <RegUserNavBar setUser={setUser} user={user} basket={basket} setBasket={setBasket} english={english} idOsoba={idOsoba}/>
            )}
        </div>
    );
}
import React, {useEffect, useState} from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

export default function AddDrink({english}){
    const navigate = useNavigate();
    const [nazwa, setNazwa] = useState("Nazwa po polsku");
    const [cena, setCena] = useState("Cena");
    const [tlumaczenie, setTlumaczenie] = useState("Nazwa po angielsku");
    const [wyslij, setWyslij] = useState("WYŚLIJ");
    const [formData, setFormData] = useState({
        nazwa: '',
        cena: 0,
        tlumaczenie: ''
    });

    useEffect(() => {
        if(english){
            setNazwa("Name in polish");
            setCena("Price");
            setTlumaczenie("Name in english");
            setWyslij("SEND");
        }else{
            setNazwa("Nazwa po polsku");
            setCena("Cena");
            setTlumaczenie("Nazwa po angielsku");
            setWyslij("WYŚLIJ");
        }
    })
    const handleInputChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log("tu jestem");
        try {
            const response = await axios.post('/Napoj', formData);
            console.log(response);
            navigate('/');
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania formularza', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className={"fixLabel"}>
                <label>{nazwa}:</label>
                <input
                    type="text"
                    name="nazwa"
                    value={formData.nazwa}
                    onChange={handleInputChange}
                />
            </div>
            <div className={"fixLabel"}>
                <label>{cena}:</label>
                <input
                    type="number"
                    name="cena"
                    value={formData.cena}
                    onChange={handleInputChange}
                />
            </div>
            <div className={"fixLabel"}>
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
    );
}
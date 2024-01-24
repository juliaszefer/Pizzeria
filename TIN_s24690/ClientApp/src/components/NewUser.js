import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import axios from "axios";

export default function NewUser({english, idOsoba, user}){
    const [text, setText] = useState("Rejestracja przebiegła pomyślnie");
    
    useEffect(() => {
        if(english){
            setText("Registration went successfully");
        }else{
            setText("Rejestracja przebiegła pomyślnie")
        }
    });

    async function setData(){
        if (user && user.idUzytkownik) {
            try{
                const resp = await axios.put(`/Osoba/UpdateOsoba?idOsoba=${idOsoba}&idUzytkownik=${user.idUzytkownik}`);
                console.log(resp);
            }catch (error){
                console.error('Wystąpił błąd podczas edycji danych', error);
            }
        }
    }

    useEffect(() => {
        setData();
    }, [user]);
    
    return (
        <div>
            <p>{text}</p>
            <button><Link to={"/"}>OK</Link></button>
        </div>
    );
}
import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import axios from "axios";

export default function NavBar({english, setEnglish, user, setUser}){
    const [zaloguj, setZaloguj] = useState("ZALOGUJ");
    const [koszyk, setKoszyk] = useState("KOSZYK")
    const [jezyk, setJezyk] = useState("EN");
    
    const [wyloguj, setWyloguj] = useState("WYLOGUJ");
    const [historia, setHistoria] = useState("HISTORIA ZAMÓWIEŃ");
    
    const [zarzadzaj, setZarzadzaj] = useState("ZARZĄDZAJ");
    
    const [idRola, setIdRola] = useState(0);
    
    const [uzytk, setUzytk] = useState(false);
    const [admi, setAdmi] = useState(false);

    const changeLanguage = () => {
        if(english){
            setEnglish(false)
            setZaloguj("ZALOGUJ");
            setKoszyk("KOSZYK");
            setJezyk("EN");
            setWyloguj("WYLOGUJ");
            setHistoria("HISTORIA ZAMÓWIEŃ");
            setZarzadzaj("ZARZĄDZAJ");
        }else{
            setEnglish(true);
            setZaloguj("LOG IN");
            setKoszyk("BASKET");
            setJezyk("PL");
            setWyloguj("LOG OUT");
            setHistoria("ORDER HISTORY");
            setZarzadzaj("MANAGE");
        }
    }
    
    useEffect(() => {
        if(user !== null && user !== undefined){
            console.log(user.idUzytkownik);
            axios.get(`/Osoba/idUzytkownik/${user.idUzytkownik}`)
                .then(response => {
                    console.log(response.data);
                    setIdRola(response.data.idRola);
                })
                .catch(error => {
                    console.error('Wystąpił błąd w trakcie szukania roli', error);
                });
        }
    }, []);
    
    useEffect(() => {
        // console.log(idRola);
       if(user !== null && idRola === 2){
           setUzytk(true);
           setAdmi(false);
       }else if(user !== null && idRola === 1){
           setUzytk(false);
           setAdmi(true);
       }else if(user === null || user === undefined){
           setUzytk(false);
           setAdmi(false);
       }
    });
    
    return (
        <header>
            {admi && (<Link to={"/Manage"}><button className={"headerButton"}>{zarzadzaj}</button></Link>)}
            {uzytk && (<Link to={"/OrderHistory"}><button className={"headerButton"}>{historia}</button></Link>)}
            <Link to={"/"} className={"headerLink"}><button className={"headerButton"}>MENU</button></Link>
            {!uzytk && !admi && (<Link to={"/LogIn"} className={"headerLink"}><button className={"headerButton"}>{zaloguj}</button></Link>)}
            {(uzytk || admi) && (<Link to={"/LogOut"}><button className={"headerButton"}>{wyloguj}</button></Link>)}
            <Link to={"/Basket"} className={"headerLink"}><button className={"headerButton"}>{koszyk}</button></Link>
            <button className={"headerButtonAfter"} onClick={changeLanguage}>{jezyk}</button>
        </header>
    );
}
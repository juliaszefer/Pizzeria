import React, {useState} from "react";
import {Link} from "react-router-dom";

export default function NavBar({english, setEnglish}){
    const [zaloguj, setZaloguj] = useState("ZALOGUJ");
    const [koszyk, setKoszyk] = useState("KOSZYK")
    const [jezyk, setJezyk] = useState("EN");

    const changeLanguage = () => {
        if(english){
            setEnglish(false)
            setZaloguj("ZALOGUJ");
            setKoszyk("KOSZYK");
            setJezyk("EN");
        }else{
            setEnglish(true);
            setZaloguj("LOG IN");
            setKoszyk("BASKET");
            setJezyk("PL");
        }
    }
    
    return (
        <header>
            <Link to={"/"} className={"headerLink"}><button className={"headerButton"}>MENU</button></Link>
            <Link to={"/LogIn"} className={"headerLink"}><button className={"headerButton"}>{zaloguj}</button></Link>
            <Link to={"/Basket"} className={"headerLink"}><button className={"headerButton"}>{koszyk}</button></Link>
            <button className={"headerButtonAfter"} onClick={changeLanguage}>{jezyk}</button>
        </header>
    );
}
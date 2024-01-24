import React, {useEffect, useState} from "react";
import LogIn from "./LogIn";
import Guest from "./Guest";

export default function OrderOsoba({english, basket, setBasket, idAdres, user, setUser}){
    const [showOrderOsoba, setShowOrderOsoba] = useState(true);
    const [zaloguj, setZaloguj] = useState("ZALOGUJ SIĘ");
    const [gosc, setGosc] = useState("KONTYNUUJ JAKO GOŚĆ")
    const [log, setLog] = useState(false);
    const [gos, setGos] = useState(false);
    
    useEffect(() => {
        if(english){
            setZaloguj("LOG IN");
            setGosc("CONTINUE AS A GUEST");
        }else{
            setZaloguj("ZALOGUJ SIĘ");
            setGosc("KONTYNUUJ JAKO GOŚĆ");
        }
    })
    const handleClickZaloguj = () => {
        setShowOrderOsoba(false);
        setLog(true);
    }
    
    const handleClickGosc = () => {
        setShowOrderOsoba(false);
        setGos(true);
    }
    
    return (
        <div>
            {showOrderOsoba && (
                <div>
                    <button onClick={handleClickZaloguj}>{zaloguj}</button>
                    <button onClick={handleClickGosc}>{gosc}</button>
                </div>
            )}
            {log && (
                <LogIn english={english} basket={basket} setBasket={setBasket} idAdres={idAdres} user={user} setUser={setUser}/>
            )}
            {gos && (
                <Guest english={english} basket={basket} setBasket={setBasket} idAdres={idAdres} user={user} setUser={setUser}/>
            )}
        </div>
    )
}
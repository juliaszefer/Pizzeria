import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";

export default function LogOut({user, setUser, english}){
    const [wylog, setWylog] = useState("Wylogowano pomyślnie");
    
    useEffect(() => {
        if(english){
            setWylog("Logging out went successfully");
        }else{
            setWylog("Wylogowano pomyślnie");
        }
    });
    
    const handleClick = () => {
        setUser(null);
    }
    
    return (
        <div>
            <p>{wylog}</p>
            <button onClick={handleClick}><Link to={"/"}>OK</Link></button>
        </div>
    )
}
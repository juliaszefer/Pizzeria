import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import NavBar from "./NavBar";

export default function LogOut({user, setUser, english, setEnglish}){
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
        <div className={"homeContainer"}>
            <NavBar user={user} setUser={setUser} english={english} setEnglish={setEnglish}/>
            <div className={"menuContainer"}>
                <div className={"menuBox"}>
                    <div className={"wylogBox"}>
                        <p>{wylog}</p>
                        <button onClick={handleClick}><Link to={"/"}>OK</Link></button>
                    </div>
                </div>
            </div>
        </div>
    )
}
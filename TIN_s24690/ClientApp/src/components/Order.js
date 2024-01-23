import React from "react";
import NavBar from "./NavBar";
import Menu from "./Menu";

export default function Order({basket, setBasket, english, setEnglish}){
    return (
        <div className={"homeContainer"}>
            <NavBar english={english} setEnglish={setEnglish}/>
            <div className={"menuContainer"}>
                
            </div>
        </div>
    );
}
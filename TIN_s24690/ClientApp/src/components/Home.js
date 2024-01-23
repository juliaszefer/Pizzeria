import React, {useState} from 'react';
import '../css/Home.css'
import Menu from "./Menu";
import NavBar from "./NavBar";

export default function Home({basket, setBasket, english, setEnglish}){
    
    return (
      <div className={"homeContainer"}>
        <NavBar english={english} setEnglish={setEnglish}/>
        <div className={"menuContainer"}>
            <Menu english={english} basket={basket} setBasket={setBasket}/>
        </div>  
      </div>
    );
}

//jesli zalogowany uzytkownik: HISTORIA ZAMOWIEN + KONTO
//jesli zalogowany administrator: ZARZADZAJ

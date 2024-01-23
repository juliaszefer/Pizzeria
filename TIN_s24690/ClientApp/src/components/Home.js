import React from 'react';
import '../css/Home.css'

export default function Home(){

    return (
      <div className={"homeContainer"}>
        <header>
            <button>MENU</button>
            <button>ZALOGUJ</button>
            <button>KOSZYK</button>
            <button>EN</button>
        </header>
        <div className={"menuContainer"}>
            <div className={"menuBox"}>
                <div className={"productName"}>

                </div>
                <div className={"productList"}>

                </div>
            </div>
        </div>  
      </div>
    );
}

//jesli zalogowany uzytkownik: HISTORIA ZAMOWIEN + KONTO
//jesli zalogowany administrator: ZARZADZAJ

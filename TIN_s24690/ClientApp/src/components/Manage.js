import React, {useEffect, useState} from "react";
import NavBar from "./NavBar";
import AddPizza from "./AddPizza";
import AddDrink from "./AddDrink";
import AddSides from "./AddSides";

export default function Manage({english, setEnglish, user, setUser}){
    const [pizz, setPizz] = useState("NOWA PIZZA");
    const [nap, setNap] = useState("NOWY NAPÓJ");
    const [dod, setDod] = useState("NOWY DODATEK");
    
    const [showAddPizza, setShowAddPizza] = useState(false);
    const [showAddDodatek, setShowAddDodatek] = useState(false);
    const [showAddNapoj, setShowAddNapoj] = useState(false);
    
    const [showButtons, setShowButtons] = useState(true);
    
    useEffect(() => {
        if(english){
            setPizz("NEW PIZZA");
            setNap("NEW DRINK");
            setDod("NEW SIDE DISH");
        }else{
            setPizz("NOWA PIZZA");
            setNap("NOWY NAPÓJ");
            setDod("NOWY DODATEK");
        }
    });
    
    const handleClickPizza = () => {
        setShowAddPizza(true);
        setShowAddDodatek(false);
        setShowAddNapoj(false);
        setShowButtons(false);
    }

    const handleClickDodatek = () => {
        setShowAddPizza(false);
        setShowAddDodatek(true);
        setShowAddNapoj(false);
        setShowButtons(false);
    }

    const handleClickNapoj = () => {
        setShowAddPizza(false);
        setShowAddDodatek(false);
        setShowAddNapoj(true);
        setShowButtons(false);
    }
    
    return (
        <div className={"homeContainer"}>
            <NavBar user={user} setUser={setUser} setEnglish={setEnglish} english={english}/>
            <div className={"menuContainer"}>
                <div className={"menuBox"}>
                    <div className={"manageDivs"}>
                        {showButtons && (
                            <div className={"placeButton"}>
                                <button onClick={handleClickPizza}>{pizz}</button>
                                <button onClick={handleClickNapoj}>{nap}</button>
                                <button onClick={handleClickDodatek}>{dod}</button>
                            </div>
                        )}
                        {showAddPizza && (
                            <AddPizza english={english}/>
                        )}
                        {showAddNapoj && (
                            <AddDrink english={english}/>
                        )}
                        {showAddDodatek && (
                            <AddSides english={english}/>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
}
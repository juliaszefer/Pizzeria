import React, {useEffect, useState} from "react";
import NavBar from "./NavBar";
import {Link} from "react-router-dom";

export default function Basket({basket, setBasket, english, setEnglish}){
    const [currentPage, setCurrentPage] = useState(1);
    const [itemsPerPage] = useState(3);
    const [emptyBasket, setEmptyBasket] = useState(false);
    const [koszykPusty, setKoszykPusty] = useState("Twój koszyk jest pusty :(");
    const [calkowitaCena, setCalkowitaCena] = useState("Całkowita suma: ");
    const [zamow, setZamow] = useState("ZAMÓW");

    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;

    const currentItems = basket.slice(indexOfFirstItem, indexOfLastItem);

    const pageNumbers = [];
    for (let i = 1; i <= Math.ceil(basket.length / itemsPerPage); i++) {
        pageNumbers.push(i);
    }

    const renderPageNumber = pageNumbers.map(number => (
        <button key={number} onClick={() => setCurrentPage(number)}>
            {number}
        </button>
    ));

    const calculateTotal = () => {
        return basket.reduce((total, item) => {
            return total + (item[0].cena * item[1]);
        }, 0);
    };


    useEffect(() => {
        if(basket.length === 0){
            setEmptyBasket(true);
            if(english){
                setKoszykPusty("Your basket is empty :(")
            }else{
                setKoszykPusty("Twój koszyk jest pusty :(")
            }
        }else{
            setEmptyBasket(false);
        }
        
        if(english){
            setCalkowitaCena("Total sum: ")
            setZamow("ORDER");
        }else{
            setCalkowitaCena("Całkowita suma: ")
            setZamow("ZAMÓW");
        }
    })

    const handleRemoveFromBasket = (itemToRemove) => {
        setBasket(prevBasket => {
            const existingItemIndex = prevBasket.findIndex(item => item[0].nazwa === itemToRemove[0].nazwa);

            if (existingItemIndex >= 0) {
                let newBasket = [...prevBasket];

                const existingItem = newBasket[existingItemIndex];

                if (existingItem[1] > 1) {
                    newBasket[existingItemIndex] = [existingItem[0], existingItem[1] - 1];
                } else {
                    newBasket.splice(existingItemIndex, 1);
                }

                return newBasket;
            }

            return prevBasket;
        });
    };


    return (
        <div className={"homeContainer"}>
            <NavBar english={english} setEnglish={setEnglish}/>
            <div className={"menuContainer"}>
                <div className={"menuBox"}>
                    <div className={"food"}>
                        {emptyBasket && (
                            <p>{koszykPusty}</p>
                        )}
                        <div className={"wrap_pizza"}>
                            {currentItems.map(item => (
                                <div key={item[0].nazwa} className="pizza-container">
                                    <div className="pizza-info">
                                        <h1>{item[1]}x {item[0].nazwa}</h1>
                                    </div>
                                    <div className="pizza-cena">
                                        <p>{item[0].cena} zł</p>
                                        <button className={"addToBasket"} onClick={() => handleRemoveFromBasket(item)}>-</button>
                                    </div>
                                </div>
                            ))}
                            {!emptyBasket && (
                                <div className="total-sum">
                                    <p>{calkowitaCena}{calculateTotal()} zł</p>
                                    <Link to={"/Order"}><button>{zamow}</button></Link>
                                </div>
                            )}
                        </div>
                        <div className="pagination">{renderPageNumber}</div>
                    </div>
                </div>
            </div>
        </div>
    );
}
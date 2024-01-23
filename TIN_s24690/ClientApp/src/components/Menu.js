import React, {useEffect, useState} from "react";
import axios from 'axios';

export default function Menu({english, basket, setBasket}) {
    const [pizza, setPizza] = useState([]);
    const [napoje, setNapoje] = useState([]);
    const [dodatki, setDodatki] = useState([]);
    const [pizzaTlumaczenie, setPizzaTlumaczenie] = useState([]);
    const [napojTlumaczenie, setNapojTlumaczenie] = useState([]);
    const [dodatkiTlumaczenie, setDodatkiTlumaczenie] = useState([]);
    const [napoj, setNapoj] = useState("NAPOJE");
    const [dodatek, setDodatek] = useState("DODATKI");
    const [pizzaJezyk, setPizzaJezyk] = useState(pizza);
    const [napojJezyk, setNapojJezyk] = useState(napoje);
    const [dodatkiJezyk, setDodatkiJezyk] = useState(dodatki);
    const [showPizza, setShowPizza] = useState(true);
    const [showNapoje, setShowNapoje] = useState(false);
    const [showDodatki, setShowDodatki] = useState(false);
    
    const [currentPagePizza, setCurrentPagePizza] = useState(1);
    const [currentPageNapoje, setCurrentPageNapoje] = useState(1);
    const [currentPageDodatki, setCurrentPageDodatki] = useState(1);

    const [itemsPerPage] = useState(3);

    const indexOfLastItemPizza = currentPagePizza * itemsPerPage;
    const indexOfFirstItemPizza = indexOfLastItemPizza - itemsPerPage;
    const indexOfLastItemNapoje = currentPageNapoje * itemsPerPage;
    const indexOfFirstItemNapoje = indexOfLastItemNapoje - itemsPerPage;
    const indexOfLastItemDodatki = currentPageDodatki * itemsPerPage;
    const indexOfFirstItemDodatki = indexOfLastItemDodatki - itemsPerPage;

    const currentPizzas = pizzaJezyk.slice(indexOfFirstItemPizza, indexOfLastItemPizza);
    const currentNapoje = napojJezyk.slice(indexOfFirstItemNapoje, indexOfLastItemNapoje);
    const currentDodatki = dodatkiJezyk.slice(indexOfFirstItemDodatki, indexOfLastItemDodatki);

    const pageNumbersPizza = [];
    for (let i = 1; i <= Math.ceil(pizzaJezyk.length / itemsPerPage); i++) {
        pageNumbersPizza.push(i);
    }

    const pageNumbersDodatki = [];
    for (let i = 1; i <= Math.ceil(dodatkiJezyk.length / itemsPerPage); i++) {
        pageNumbersDodatki.push(i);
    }

    const pageNumbersNapoje = [];
    for (let i = 1; i <= Math.ceil(napojJezyk.length / itemsPerPage); i++) {
        pageNumbersNapoje.push(i);
    }
    
    const handleAddToBasket = (item) => {
        setBasket(prevBasket => {
            const existingItem = prevBasket.find(basketItem => basketItem[0].nazwa === item.nazwa);

            if (existingItem) {
                return prevBasket.map(basketItem =>
                    basketItem[0].nazwa === item.nazwa
                        ? [basketItem[0], basketItem[1] + 1]
                        : basketItem
                );
            } else {
                return [...prevBasket, [item, 1]];
            }
        });
    }


    useEffect(() => {
        axios.get('/Pizza')
            .then(response => {
                setPizza(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
        axios.get('/Dodatek')
            .then(response => {
                setDodatki(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
        axios.get('/Napoj')
            .then(response => {
                setNapoje(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });

        axios.get('/PizzaTlumaczenie')
            .then(response => {
                setPizzaTlumaczenie(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
        axios.get('/DodatekTlumaczenie')
            .then(response => {
                setDodatkiTlumaczenie(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
        axios.get('/NapojTlumaczenie')
            .then(response => {
                setNapojTlumaczenie(response.data);
            })
            .catch(error => {
                console.error('Wystąpił błąd', error);
            });
    }, []);
    
    useEffect(() => {
        if (english) {
            setNapoj("DRINKS");
            setDodatek("SIDE DISHES");
            setPizzaJezyk(pizzaTlumaczenie);
            setNapojJezyk(napojTlumaczenie);
            setDodatkiJezyk(dodatkiTlumaczenie);
        } else {
            setNapoj("NAPOJ");
            setDodatek("DODATKI")
            setPizzaJezyk(pizza);
            setNapojJezyk(napoje);
            setDodatkiJezyk(dodatki);
        }
    })
    
    const handleClickPizza = () => {
        setShowPizza(true);
        setShowDodatki(false);
        setShowNapoje(false);
    }
    
    const handleClickNapoje = () => {
        setShowPizza(false);
        setShowDodatki(false);
        setShowNapoje(true);
    }
    
    const handleClickDodatki = () => {
        setShowPizza(false);
        setShowDodatki(true);
        setShowNapoje(false);
    }

    const renderPageNumbersPizza = pageNumbersPizza.map(number => (
        <button key={number} onClick={() => setCurrentPagePizza(number)}>
            {number}
        </button>
    ));

    const renderPageNumberDodatki = pageNumbersDodatki.map(number => (
        <button key={number} onClick={() => setCurrentPageDodatki(number)}>
            {number}
        </button>
    ));

    const renderPageNumbersNapoje = pageNumbersNapoje.map(number => (
        <button key={number} onClick={() => setCurrentPageNapoje(number)}>
            {number}
        </button>
    ));

    return (
        <div className={"menuBox"}>
            <div className={"productName"}>
                <button onClick={handleClickPizza}>PIZZA</button>
                <button onClick={handleClickNapoje}>{napoj}</button>
                <button onClick={handleClickDodatki}>{dodatek}</button>
            </div>
            <div className={"productList"}>
                {showPizza && (<div className={"food"}>
                    <div className={"wrap_pizza"}>
                        {currentPizzas.map(pizzas => (
                            <div key={pizzas.nazwa} className="pizza-container">
                                <div className="pizza-info">
                                    <h1>{pizzas.nazwa}</h1>
                                    <p>{pizzas.skladniks.map(s => s.nazwa).join(', ')}</p>
                                </div>
                                <div className="pizza-cena">
                                    <p>{pizzas.cena} zł</p>
                                    <button className={"addToBasket"} onClick={() => handleAddToBasket(pizzas)}>+</button>
                                </div>
                            </div>
                        ))}
                    </div>
                    <div className="pagination">{renderPageNumbersPizza}</div>
                </div>)}
                {showNapoje && (<div className={"food"}>
                    <div className={"wrap_pizza"}>
                        {currentNapoje.map(napoj => (
                            <div key={napoj.nazwa} className="pizza-container">
                                <div className="pizza-info">
                                    <h1>{napoj.nazwa}</h1>
                                </div>
                                <div className="pizza-cena">
                                    <p>{napoj.cena} zł</p>
                                    <button className={"addToBasket"} onClick={() => handleAddToBasket(napoj)}>+</button>
                                </div>
                            </div>
                        ))}
                    </div>
                    <div className="pagination">{renderPageNumbersNapoje}</div>
                </div>)}
                {showDodatki && (<div className={"food"}>
                    <div className={"wrap_pizza"}>
                        {currentDodatki.map(dodatki => (
                            <div key={dodatki.nazwa} className="pizza-container">
                                <div className="pizza-info">
                                    <h1>{dodatki.nazwa}</h1>
                                </div>
                                <div className="pizza-cena">
                                    <p>{dodatki.cena} zł</p>
                                    <button className={"addToBasket"} onClick={() => handleAddToBasket(dodatki)}>+</button>
                                </div>
                            </div>
                        ))}
                    </div>
                    <div className="pagination">{renderPageNumberDodatki}</div>
                </div>)}
            </div>
        </div>
    );
}
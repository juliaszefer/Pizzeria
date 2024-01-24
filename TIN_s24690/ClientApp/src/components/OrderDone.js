import React, {useEffect, useState} from "react";
import axios from "axios";
import {Link} from "react-router-dom";

export default function OrderDone({english, basket, setBasket, user, setUser, idOsoba}) {
    const [pizza, setPizza] = useState([]);
    const [napoje, setNapoje] = useState([]);
    const [dodatki, setDodatki] = useState([]);
    const [pizzaTlumaczenie, setPizzaTlumaczenie] = useState([]);
    const [napojTlumaczenie, setNapojTlumaczenie] = useState([]);
    const [dodatkiTlumaczenie, setDodatkiTlumaczenie] = useState([]);

    const [pizzaZamowienie, setPizzaZamowienie] = useState([]);
    const [dodatekZamowienie, setDodatekZamowienie] = useState([]);
    const [napojZamowienie, setNapojZamowienie] = useState([]);

    const [uniquepizzaZamowienie, setuniquePizzaZamowienie] = useState([]);
    const [uniquedodatekZamowienie, setuniqueDodatekZamowienie] = useState([]);
    const [uniquenapojZamowienie, setuniqueNapojZamowienie] = useState([]);

    const [idZamowienie, setIdZamowienie] = useState(0);

    const [text, setText] = useState('Zamówienie przyjęte do realizacji');

    useEffect(() => {
        console.log(basket)
        if (english) {
            setText("Your order has been accepted for processing");
        } else {
            setText('Zamówienie przyjęte do realizacji');
        }
    })

    useEffect(() => {
        console.log(basket);
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

        basket.forEach((elementBasket) => {
            pizza.forEach((element) => {
                if (elementBasket[0].nazwa === element.nazwa) {
                    pizzaZamowienie.push(elementBasket);
                    console.log(elementBasket);
                }
            });
            pizzaTlumaczenie.forEach((element) => {
                if (elementBasket[0].nazwa === element.nazwa) {
                    pizzaZamowienie.push(elementBasket);
                }
            });
            napoje.forEach((element) => {
                if (elementBasket[0].nazwa === element.nazwa) {
                    napojZamowienie.push(elementBasket);
                }
            });
            napojTlumaczenie.forEach((element) => {
                if (elementBasket[0].nazwa === element.nazwa) {
                    napojZamowienie.push(elementBasket);
                }
            });
            dodatki.forEach((element) => {
                if (elementBasket[0].nazwa === element.nazwa) {
                    dodatekZamowienie.push(elementBasket);
                }
            });
            dodatkiTlumaczenie.forEach((element) => {
                if (elementBasket[0].nazwa === element.nazwa) {
                    dodatekZamowienie.push(elementBasket);
                }
            });
        });
        const uniqueMap = new Map();

        pizzaZamowienie.forEach(item => {
            if (!uniqueMap.has(item[0].idPizza)) {
                uniqueMap.set(item[0].idPizza, item);
            }
        });
        
        setuniquePizzaZamowienie(Array.from(uniqueMap.values()));
        
        const uniqueMap2 = new Map();

        napojZamowienie.forEach(item => {
            if (!uniqueMap2.has(item[0].idNapoj)) {
                uniqueMap2.set(item[0].idNapoj, item);
            }
        });

        setuniqueNapojZamowienie(Array.from(uniqueMap2.values()));

        const uniqueMap3 = new Map();

        dodatekZamowienie.forEach(item => {
            if (!uniqueMap3.has(item[0].idDodatek)) {
                uniqueMap3.set(item[0].idDodatek, item);
            }
        });

        setuniqueDodatekZamowienie(Array.from(uniqueMap3.values()));
        
    }, [basket]);

    const handleZamowienie = async (event) => {
        event.preventDefault();
        
        console.log("pizza zamowinie:" + uniquepizzaZamowienie);
        console.log(uniquenapojZamowienie);
        console.log(uniquedodatekZamowienie);
        
        try {
            const response = await axios.post(`/Zamowienie/Zamowienie?idOsoba=${idOsoba}`);
            setIdZamowienie(response.data);
            console.log("ID:" + idZamowienie);
            console.log(response);
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania danych', error);
        }

        try {
            if(uniquepizzaZamowienie.length !== 0) {
                for (const element of uniquepizzaZamowienie) {
                    const pizza = {
                        idZamowienie: idZamowienie,
                        idPizza: element[0].idPizza,
                        ilosc: element[1]
                    }
                    console.log(pizza);
                    const response = await axios.post(`Zamowienie/ZamowieniePizza?idZamowienie=${pizza.idZamowienie}&idPizza=${pizza.idPizza}&ilosc=${pizza.ilosc}`);
                    console.log(response);
                }
            }
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania danych', error);
        }

        try {
            if(uniquenapojZamowienie.length !== 0) {
                for (const element of uniquenapojZamowienie) {
                    const napoj = {
                        idZamowienie: idZamowienie,
                        idNapoj: element[0].idNapoj,
                        ilosc: element[1]
                    }

                    const response = await axios.post('Zamowienie/ZamowienieNapoj', napoj);
                    console.log(response);

                }
            }
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania danych', error);
        }

        try {
            if(uniquedodatekZamowienie.length !== 0) {
                for (const element of uniquedodatekZamowienie) {
                    const dodatek = {
                        idZamowienie: idZamowienie,
                        idDodatek: element[0].idDodatek,
                        ilosc: element[1]
                    }

                    const response = await axios.post('Zamowienie/ZamowienieDodatek', dodatek);
                    console.log(response);

                }
            }
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania danych', error);
        }
        
    }

    return (
        <div>
            <p>{text}</p>
            <button onClick={handleZamowienie}><Link to={"/"}>OK</Link></button>
        </div>
    )
}
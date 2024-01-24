import React, {useEffect, useState} from "react";
import axios from "axios";
import OrderDone from "./OrderDone";
import Register from "./Register";
import Order from "./Order";
import {Link} from "react-router-dom";
import AdresNavBar from "./AdresNavBar";

export default function LogInNavBar({english, setEnglish, basket, setBasket, user, setUser, idAdres, setIdAdres}){
    const [log, setLog] = useState("ZALOGUJ SIĘ");
    const [reg, setReg] = useState("ZAREJESTRUJ SIĘ");
    const [has, setHas] = useState("Hasło");

    const [idOsoba, setIdOsoba] = useState(0);

    const [showLog, setShowLog] = useState(true);
    const [userLogged, setUserLogged] = useState(true);
    const [regShow, setRegShow] = useState(false);
    const [orderShow, setOrderShow] = useState(false);

    const [git, setGit] = useState("Zalogowano pomyślnie! Witaj, ");

    useEffect(() => {
        if (english) {
            setLog("LOG IN");
            setReg("REGISTER");
            setGit("Logging in went successfully, Welcome, ");
            setHas("Password");
        } else {
            setLog("ZALOGUJ SIĘ");
            setReg("ZAREJESTRUJ SIĘ");
            setGit("Zalogowano pomyślnie! Witaj, ");
            setHas("Hasło");
        }

        if(user !== null){
            setUserLogged(false);
        }else{
            setUserLogged(true);
        }
    })

    const [loginData, setLoginData] = useState({
        login: '',
        haslo: ''
    });
    const [errorMessage, setErrorMessage] = useState('');

    const handleInputChange = (e) => {
        setLoginData({
            ...loginData,
            [e.target.name]: e.target.value
        });
    };

    const handleOnClickOK = () => {
        setShowLog(false);
        setOrderShow(true);
    }

    const handleOnLickRegister = () => {
        setShowLog(false);
        setRegShow(true);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.get(`/Uzytkownik/${loginData.login}/${loginData.haslo}`);
            setUser(response.data);
            setErrorMessage('');
            console.log(response.data);
        } catch (error) {
            if (error.code === "ERR_NOT_FOUND") {
                if (english) {
                    setErrorMessage('Wrong login or password.');
                } else {
                    setErrorMessage('Nieprawidłowy login lub hasło.');
                }
            } else {
                console.error('Wystąpił błąd', error);
            }
        }
    };

    useEffect(() => {
        if(user !== null && user !== undefined) {
            if (user && user.idUzytkownik) {
                axios.get(`/Osoba/idUzytkownik/${user.idUzytkownik}`)
                    .then(response => {
                        setIdOsoba(response.data.idOsoba);
                    })
                    .catch(error => {
                        console.error('Wystąpił błąd', error);
                    });
            }
        }
    }, [user]);

    return (
        <div>
            {showLog && (
                <div>
                    {userLogged && (
                        <form onSubmit={handleSubmit}>
                            <input
                                type="text"
                                name="login"
                                value={loginData.login}
                                onChange={handleInputChange}
                                placeholder="Login"
                            />
                            <input
                                type="password"
                                name="haslo"
                                value={loginData.haslo}
                                onChange={handleInputChange}
                                placeholder={has}
                            />
                            <button type="submit">{log}</button>
                            {errorMessage && <p>{errorMessage}</p>}
                        </form>
                    )}
                    {user && <div>
                        <p>{git}{user.login}</p>
                        <button onClick={handleOnClickOK}><Link to={"/"}>OK</Link></button>
                    </div>}
                    <button onClick={handleOnLickRegister}>{reg}</button>
                </div>
            )}
            {regShow && (
                <AdresNavBar setIdAdres={setIdAdres} english={english} idAdres={idAdres} user={user} setUser={setUser} basket={basket} setBasket={setBasket} setEnglish={setEnglish}/>
            )}
        </div>
    );
}
import React, {useEffect, useState} from "react";
import axios from "axios";
import OrderDone from "./OrderDone";
import NewUser from "./NewUser";

export default function RegUserNavBar({basket, setBasket, user, setUser, english, idOsoba}){
    const [haslo, setHaslo] = useState("Hasło");
    const [log, setLog] = useState("ZAREJESTRUJ SIĘ");
    const [showRegUser, setShowRegUser] = useState(true);
    const [showOrderDone, setshowOrderDone] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [showError, setShowError] = useState(false);

    useEffect(() => {
        if(english){
            setHaslo("Password");
            setLog("REGISTER");
        }else{
            setHaslo("Hasło");
            setLog("ZAREJESTRUJ SIĘ");
        }
    })

    const [loginData, setLoginData] = useState({
        login: '',
        hasloHash: ''
    });

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setLoginData({
            ...loginData,
            [name]: value
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await axios.post('/Uzytkownik', loginData);
            console.log(response);

            axios.get(`/Uzytkownik/${loginData.login}/${loginData.hasloHash}`)
                .then(response => {
                    setUser(response.data);
                    setErrorMessage('');
                    setShowError(false);
                    setShowRegUser(false);
                    setshowOrderDone(true);
                })
                .catch(error => {
                    console.error('Wystąpił błąd', error);
                });
        } catch (error) {
            console.error('Wystąpił błąd podczas wysyłania danych', error);
            if (error.code === "ERR_NOT_FOUND") {
                setShowError(true);
                if(english){
                    setErrorMessage('Login already exists.');
                }else{
                    setErrorMessage('Login już istnieje.');
                }
            } else {
                console.error('Wystąpił błąd', error);
            }
        }
    };

    return (
        <div>
            {showRegUser && (
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
                        name="hasloHash"
                        value={loginData.hasloHash}
                        onChange={handleInputChange}
                        placeholder={haslo}
                    />
                    <button type="submit">{log}</button>
                    {showError && (<p>{errorMessage}</p>)}
                </form>
            )}
            {showOrderDone && (
                <NewUser english={english} idOsoba={idOsoba} user={user}/>
            )}
        </div>
    );
}
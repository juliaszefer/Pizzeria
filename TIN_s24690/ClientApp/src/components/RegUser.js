import React, {useEffect, useState} from "react";
import axios from "axios";
import OrderDone from "./OrderDone";

export default function RegUser({basket, setBasket, user, setUser, english, idOsoba}){
    const [haslo, setHaslo] = useState("Hasło");
    const [log, setLog] = useState("ZALOGUJ SIĘ");
    const [showRegUser, setShowRegUser] = useState(true);
    const [showOrderDone, setshowOrderDone] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [showError, setShowError] = useState(false);
    
    useEffect(() => {
        if(english){
            setHaslo("Password");
            setLog("LOG IN");
        }else{
            setHaslo("Hasło");
            setLog("ZALOGUJ SIĘ");
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

    useEffect(() => {
        if (user && user.idUzytkownik) {
            try{
                const resp = axios.put('/Osoba/UpdateOsoba', user.idUzytkownik);
                console.log(resp);
            }catch (error){
                console.error('Wystąpił błąd podczas edycji danych', error);
            }
        }
    }, [user]);

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
                <OrderDone user={user} setUser={setUser} english={english} idOsoba={idOsoba} setBasket={setBasket} basket={basket}/>
            )}
        </div>
    );
}
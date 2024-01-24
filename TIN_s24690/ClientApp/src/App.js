import React, {useState} from 'react';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import './custom.css';
import Home from "./components/Home";
import Basket from "./components/Basket";
import LogIn from "./components/LogIn";
import Order from "./components/Order";
export default function App(){
    const [basket, setBasket] = useState([]);
    const [english, setEnglish] = useState(false);
    const [user, setUser] = useState(null);
    const [idAdres, setIdAdres] = useState(0);
    
    return (
      <BrowserRouter>
        <Routes>
          <Route path={"/"} element={<Home basket={basket} setBasket={setBasket} english={english} setEnglish={setEnglish} user={user} setUser={setUser}/>}/>
          <Route path={"/Basket"} element={<Basket basket={basket} setBasket={setBasket} english={english} setEnglish={setEnglish} user={user} setUser={setUser}/>}/>  
          <Route path={"/LogIn"} element={<LogIn english={english} basket={basket} setBasket={setBasket} idAdres={idAdres} user={user} setUser={setUser}/>}/>  
          <Route path={"/Order"} element={<Order basket={basket} setBasket={setBasket} english={english} setEnglish={setEnglish} setIdAdres={setIdAdres} idAdres={idAdres} user={user} setUser={setUser}/>}/>
        </Routes>
      </BrowserRouter>
    );
}

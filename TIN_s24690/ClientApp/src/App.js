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
    
    return (
      <BrowserRouter>
        <Routes>
          <Route path={"/"} element={<Home basket={basket} setBasket={setBasket} english={english} setEnglish={setEnglish}/>}/>
          <Route path={"/Basket"} element={<Basket basket={basket} setBasket={setBasket} english={english} setEnglish={setEnglish}/>}/>  
          <Route path={"/LogIn"} element={<LogIn/>}/>  
          <Route path={"/Order"} element={<Order/>}/>  
        </Routes>
      </BrowserRouter>
    );
}

import React, {useState} from 'react';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import './custom.css';
import Home from "./components/Home";
import Basket from "./components/Basket";
import Order from "./components/Order";
import OrderHistory from "./components/OrderHistory";
import Manage from "./components/Manage";
import LogInNavBar from "./components/LogInNavBar";
import LogOut from "./components/LogOut";
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
          <Route path={"/LogIn"} element={<LogInNavBar english={english} setEnglish={setEnglish} basket={basket} setBasket={setBasket} idAdres={idAdres} setIdAdres={setIdAdres} user={user} setUser={setUser}/>}/>  
          <Route path={"/Order"} element={<Order basket={basket} setBasket={setBasket} english={english} setEnglish={setEnglish} setIdAdres={setIdAdres} idAdres={idAdres} user={user} setUser={setUser}/>}/>
          <Route path={"/OrderHistory"} element={<OrderHistory user={user} setUser={setUser} english={english} setEnglish={setEnglish}/>}/>
          <Route path={"/Manage"} element={<Manage/>}/>  
          <Route path={"/LogOut"} element={<LogOut user={user} setUser={setUser} english={english}/>}/>  
        </Routes>
      </BrowserRouter>
    );
}

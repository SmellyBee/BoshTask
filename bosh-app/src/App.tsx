import React from 'react';
import './App.css';
import CartItem from './Components/CartItem/CartItem';
import CartItemsPage from './Routs/CartItemsPage/CartItemsPage';
import { Route, Router, Routes } from 'react-router-dom';
import SpecificProductPage from './Routs/SpecficProductPage/SpecificProductPage';
import ErrorPage from './Routs/ErrorPage/ErrorPage';
import { ToastContainer } from 'react-toastify';
import CartPage from './Routs/CartPage/CartPage';
import CartIcon from './Components/CartIcon/CartIcon';

function App() {
  return (
    <>
      <ToastContainer position="top-right" autoClose={3000} theme="colored" />

      <CartIcon/>

      <Routes>
          <Route path="/" element={<CartItemsPage/>} />
          <Route path="/product/:id" element={<SpecificProductPage />} />
          <Route path='/404' element={<ErrorPage/>}/>
          <Route path='/cart' element={<CartPage/>}/>
        </Routes>
      
    </>
    
  );
}

export default App;

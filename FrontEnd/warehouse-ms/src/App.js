import React from 'react';
import Header from './Components/Header';
import Footer from './Components/Footer';
import {Route, Routes } from "react-router-dom";
import Products from './Components/Products';
import Home from './Components/Home';

class App extends React.Component
{


  render() {
    return(
      <div>

      <Header />
      <Routes>
    

      <Route path="/" element={<Home />} />
      <Route path="products" element={<Products />} />

      </Routes>
    
      <Footer />

      </div>

    );
  }

}

export default App 
import React from 'react';
import './Header.css';
import { Link } from "react-router-dom";
// import { View, Text } from "react-native";


class Header extends React.Component {
  render() {

    return (
      <div id="header">

       
         
          <Link to="/">
            <p>Home</p> 
          </Link>

          <Link to="products">
            <p>Products</p>
          </Link>
        
      </div>

    );
  }
}
export default Header
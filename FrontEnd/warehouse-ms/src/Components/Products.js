import React from 'react';
import axios from 'axios';
import ProductCard from './ProductCard';
import "./Products.css";

class Products extends React.Component
{

  constructor(props){
    super(props);
    this.state = {
      productQeuryResult: []
    }
  }

  // getProducts = async () =>{
  //   let url = "http://localhost:32268/api/products";
  //   let products = await axios.get(url)
  //   console.log(products.data);
  //   this.setState({
  //     productQeuryResult: products.data
  //   })
  //   // console.log(this.state.productQeuryResult)
  // }

componentDidMount(){
  axios.get('http://localhost:32268/api/products')
  .then(res => {
    const products = res.data;
    this.setState({productQeuryResult: products });
  })

}

  render() {
    return(
      <div id="main">
     

       {
            this.state.productQeuryResult.map(e=>{
              
              return (
               <div id="card">

                <ProductCard show={e}/>
               </div>
               
                );
                
            })
           
        }

       

      </div>
    );
  }

}

export default Products 
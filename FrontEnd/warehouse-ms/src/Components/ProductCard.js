import React, { Component } from 'react';
import Card from 'react-bootstrap/Card';
import 'bootstrap/dist/css/bootstrap.min.css'; 

class ProductCard extends Component{

    render(){
        return(
            <div>
                  <Card
                    bg='info'
                    border="info"
                    style={{ width: '18rem', margin:'10px' }}
                    className="mb-2"
                  >
                    <Card.Header></Card.Header>
                    <Card.Body>
                        <Card.Title> Product </Card.Title>
                        <Card.Text>
                           <p>name: {this.props.show.name}</p>
                           <p>weight: {this.props.show.weight}</p>
                        </Card.Text>
                    </Card.Body>
                </Card>
            </div>
        )
    }
}

export default ProductCard
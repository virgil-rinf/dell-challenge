import React, { Component } from "react";
import Validation from "../validation";

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    this.loadProducts();
  }

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
        <table>
            {items.map(item => (
                
                  <tr>
                    <td>- {item.name} - {item.category}</td>
                    <td><button className="btn btn-edit"> Edit </button></td>
                    <td><button className="btn btn-danger" onClick={() => this.deleteProduct(item.id)}> Delete </button></td>                    
                  </tr>                               
            ))}
          </table> 
      );
    }
  }

  loadProducts(){
    fetch("http://localhost:2534/api/products")
        .then(res => res.json())
        .then(
          result => {
            this.setState({
              isLoaded: true,
              items: result
            });
          },
          // Note: it's important to handle errors here
          // instead of a catch() block so that we don't swallow
          // exceptions from actual bugs in components.
          error => {
            this.setState({
              isLoaded: true,
              error
            });
          }
        );
  }

  deleteProduct(id){
    fetch("http://localhost:2534/api/products/" + id, {
      method: "DELETE",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors"
    })
    .then(res => res.json())
    .then(this.loadProducts())
    .catch(err => console.log(err));    
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;

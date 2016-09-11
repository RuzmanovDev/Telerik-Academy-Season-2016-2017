/* globals module */

"use strict";

function solve() {
    function isProductLike(item) {
        Object.keys(Product).every(function (prop) {
            return Product[prop] === item[prop];
        });
    }

    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType() {
            return this._productType;
        }

        set productType(value) {
            this._productType = value;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            this._name = value;
        }

        get price() {
            return this._price;
        }

        set price(value) {
            this._price = value;
        }
    }

    class ShoppingCart {
        constructor() {
            this._products = [];
        }

        add(product) {
            if (product instanceof Product || isProductLike(product)) {
                this.products.push(product);
            }
            return this;
        }

        get products() {
            return this._products;
        }

        remove(product) {
            if (this._products.length === 0) {
                throw  new Error("There are no products in the shopping cart");
            }
            if (product instanceof Product || isProductLike(product)) {
                if (this._products.length === 0) {
                    throw new Error("The shopping cart is empty!")
                }
                var valueToRemove = this._products.findIndex(pr=>pr.name === product.name
                && pr.price === product.price && pr.productType === product.productType);

                if (valueToRemove <= -1) {
                    throw  new Error("There is no such item in the shopping cart!")
                }

                this._products.splice(valueToRemove, 1);
            }
        }

        showCost() {
            if (this._products.length === 0) {
                return 0;
            }
            var cost = 0;
            for (let item of this._products) {
                cost += item.price;
            }
            return cost;
        }

        showProductTypes() {
            var uniqueProductTypes = {};

            for (let item of this._products) {
                uniqueProductTypes[item.productType] = 1;
            }
            return Object.keys(uniqueProductTypes).sort(function (a, b) {
                if (a < b) return -1;
                if (a > b) return 1;
                return 0;
            });
        }

        getInfo() {
            if (this._products.length === 0) {
                return {
                    totalPrice: 0,
                    products: []
                }
            }
            var result = {};
            // result[totalPrice] = 0;
            result.totalPrice = this.showCost();
            result.products = [];

            result.products.push({
                name: this._products[0].name,
                totalPrice: this._products[0].price,
                quantity: 1
            });

            for (let i = 1, len = this._products.length; i < len; i += 1) {
                let found = false;
                var currentProduct = this._products[i];
                for (let pr of result.products) {
                    if (pr.name === currentProduct.name) {
                        pr.quantity += 1;
                        pr.totalPrice += currentProduct.price;
                        found = true;
                    }
                }

                if (!found) {
                    result.products.push({
                        name: this.products[i].name,
                        totalPrice: this.products[i].price,
                        quantity: 1
                    });
                }
            }


            return result;
        }
    }

    return {
        Product,
        ShoppingCart
    };
}

module.exports = solve;
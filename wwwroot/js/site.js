// Cart logic

// Load cart from localStorage or initialize it
let cart = JSON.parse(localStorage.getItem('cart')) || [];

// Update cart count in the navbar
function updateCartCount() {
    document.getElementById('cart-count').innerText = cart.reduce((total, item) => total + item.quantity, 0);
}

// Save cart to localStorage
function saveCart() {
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartCount();
}

// Add item to cart
function addToCart(productId) {
    const existingItem = cart.find(item => item.productId === productId);
    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cart.push({ productId, quantity: 1 });
    }
    saveCart();
    alert('Item added to cart');
}

// Remove item from cart
function removeFromCart(productId) {
    cart = cart.filter(item => item.productId !== productId);
    saveCart();
    renderCart();
}

// Adjust item quantity in cart
function adjustQuantity(productId, quantity) {
    const item = cart.find(item => item.productId === productId);
    if (item) {
        item.quantity = parseInt(quantity, 10);
        if (item.quantity <= 0) {
            removeFromCart(productId);
        } else {
            saveCart();
            renderCart();
        }
    }
}

// Render cart items in the cart view
function renderCart() {
    const cartContainer = document.getElementById('cart-container');
    cartContainer.innerHTML = '';
    cart.forEach(item => {
        const product = products.find(p => p.productId === item.productId);
        if (product) {
            const cartItem = document.createElement('div');
            cartItem.classList.add('col-md-4', 'mb-4');
            cartItem.innerHTML = `
                <div class="card h-100">
                    <img src="${product.imageUrl}" class="card-img-top img-fluid" alt="${product.name}">
                    <div class="card-body">
                        <h5 class="card-title">${product.name}</h5>
                        <p class="card-text">${product.description}</p>
                        <p class="card-text"><strong>Price:</strong> $${product.price}</p>
                        <p class="card-text"><strong>Category:</strong> ${product.category}</p>
                        <p class="card-text"><strong>Quantity:</strong> <input type="number" value="${item.quantity}" min="1" class="form-control quantity-input" style="width: 100px; display: inline;" onchange="adjustQuantity('${item.productId}', this.value)"></p>
                        <button class="btn btn-danger" onclick="removeFromCart('${item.productId}')">Remove</button>
                    </div>
                </div>
            `;
            cartContainer.appendChild(cartItem);
        }
    });
}

// Initialize cart view on page load
document.addEventListener('DOMContentLoaded', function () {
    if (document.getElementById('cart-container')) {
        renderCart();
    }
    updateCartCount();
});

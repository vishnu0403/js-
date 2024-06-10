<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>CRUD Example</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            width: 50%;
            margin: auto;
        }
        .user-list {
            margin-top: 20px;
        }
        .user-item {
            display: flex;
            justify-content: space-between;
            padding: 10px;
            border-bottom: 1px solid #ccc;
        }
        .user-item button {
            margin-left: 5px;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>User Management</h1>
        <div>
            <input type="text" id="username" placeholder="Enter username">
            <button id="addUser">Add User</button>
        </div>
        <div class="user-list" id="userList"></div>
    </div>

    <script>
        class UserManager {
            constructor() {
                this.users = [];
                this.userId = 1;
            }

            addUser(username) {
                if (username) {
                    this.users.push({ id: this.userId++, name: username });
                    this.renderUsers();
                }
            }

            updateUser(id, newName) {
                const user = this.users.find(user => user.id === id);
                if (user) {
                    user.name = newName;
                    this.renderUsers();
                }
            }

            deleteUser(id) {
                this.users = this.users.filter(user => user.id !== id);
                this.renderUsers();
            }

            renderUsers() {
                const userList = document.getElementById('userList');
                userList.innerHTML = '';

                this.users.forEach(user => {
                    const userItem = document.createElement('div');
                    userItem.className = 'user-item';
                    userItem.innerHTML = `
                        <span>${user.name}</span>
                        <div>
                            <button onclick="editUser(${user.id})">Edit</button>
                            <button onclick="deleteUser(${user.id})">Delete</button>
                        </div>
                    `;
                    userList.appendChild(userItem);
                });
            }
        }

        const userManager = new UserManager();

        document.getElementById('addUser').addEventListener('click', () => {
            const username = document.getElementById('username').value;
            userManager.addUser(username);
            document.getElementById('username').value = '';
        });

        window.editUser = function(id) {
            const newName = prompt('Enter new username:');
            if (newName) {
                userManager.updateUser(id, newName);
            }
        };

        window.deleteUser = function(id) {
            if (confirm('Are you sure you want to delete this user?')) {
                userManager.deleteUser(id);
            }
        };
    </script>
</body>
</html>

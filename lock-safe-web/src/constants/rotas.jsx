const API_URL = "https://localhost:7293/";

const rotas = {
    createUser: `${API_URL}api/Users`,
    createPassword: `${API_URL}api/Password/create`,
    login: `${API_URL}api/Login/login`, 
};

export default rotas;

import rotas from "../../constants/rotas";
import { toast } from "react-toastify";

const loginService = {
  login: async (UserName, Password) => {
    try {
      const response = await fetch(rotas.login, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
            UserName,
            Password,
        }),
      });

      if (!response.ok) {
        throw new Error("Usuário ou senha inválidos.");
      }

      const data = await response.json();
      // Armazenando o token no localStorage
      localStorage.setItem("token", data.token);

      toast.success("Login realizado com sucesso!");

      // Retornando os dados do usuário e o token
      return {
        userName: data.userName,
        email: data.email,
        token: data.token,
      };
    } catch (error) {
      throw new Error(error.message);
    }
  },
  logout: () => {
    // Remover o token ao fazer logout
    localStorage.removeItem("token");
  },
  getToken: () => {
    return localStorage.getItem("token");
  },
  isAuthenticated: () => {
    // Verifica se o token existe
    return !!localStorage.getItem("token");
  },
};

export default loginService;

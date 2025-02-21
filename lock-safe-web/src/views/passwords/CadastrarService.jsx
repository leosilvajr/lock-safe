import rotas from "../../constants/rotas";
import { toast } from "react-toastify";

const CadastrarService = {
  createPassword: async (passwordData) => {
    // Recupera o token do localStorage
    const token = localStorage.getItem("token");

    const response = await fetch(rotas.createPassword, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`,  // Adiciona o token no cabeçalho
      },
      body: JSON.stringify(passwordData),
    });

    toast.success("Senha cadastrada com sucesso!");

    if (!response.ok) {
      throw new Error("Erro ao cadastrar a senha");
    }

    return response.json();
  },
};

export default CadastrarService;

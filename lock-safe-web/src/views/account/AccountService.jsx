import { useState } from "react";
import { toast } from "react-toastify";
import rotas from "../../constants/rotas";

const AccountService = () => {
  const [formData, setFormData] = useState({
    fullName: "",
    userName: "",
    email: "",
    profileImageUrl: "",
    password: "",
  });

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    try {
      const response = await fetch(rotas.createUser, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });

      if (!response.ok) {
        const errorMessage = await response.text();
        throw new Error(errorMessage);
      }

      toast.success("Cadastro realizado com sucesso!");
      setFormData({ fullName: "", userName: "", email: "", profileImageUrl: "", password: "" });
    } catch (error) {
      toast.error(`Erro ao cadastrar: ${error.message}`);
    }
  };

  return { formData, handleChange, handleSubmit };
};

export default AccountService;

import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import CadastrarService from "./CadastrarService";

const Cadastrar = () => {
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    title: "",
    description: "",
    reference: "",
    account: "",
    passwordValue: "",
    expirationDate: "",
    isAdmin: false,
  });

  const [errors, setErrors] = useState({});
  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState("");

  // Validação do formulário
  const validate = () => {
    let newErrors = {};

    if (!formData.title.trim()) newErrors.title = "O título é obrigatório.";
    if (!formData.description.trim()) newErrors.description = "A descrição é obrigatória.";
    if (!formData.reference.trim()) newErrors.reference = "A referência é obrigatória.";
    if (!formData.account.trim()) newErrors.account = "A conta é obrigatória.";
    if (!formData.passwordValue.trim()) newErrors.passwordValue = "A senha é obrigatória.";
    if (!formData.expirationDate) newErrors.expirationDate = "A data de expiração é obrigatória.";

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  // Atualizar os campos do formulário
  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData({ ...formData, [name]: type === "checkbox" ? checked : value });
  };

  // Submissão do formulário
  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!validate()) return;

    setLoading(true);
    setMessage("");

    try {
      await CadastrarService.createPassword(formData);
      setMessage("Senha cadastrada com sucesso!");
      setTimeout(() => navigate("/home"), 2000);
    } catch (error) {
      setMessage("Erro ao cadastrar a senha. Tente novamente.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex-1 bg-zinc-100 space-y-6 px-12 py-6">

      <form onSubmit={handleSubmit} className="bg-white p-6 rounded-lg shadow-md space-y-8 ">
        
        {/* Primeira linha: Título, Referência, Conta */}
        <div className="grid grid-cols-3 gap-4">
          <div>
            <label className="block text-sm font-medium text-zinc-700">Título</label>
            <input
              type="text"
              name="title"
              value={formData.title}
              onChange={handleChange}
              className="w-full p-2 border rounded-md focus:ring-2 focus:ring-blue-500"
            />
            {errors.title && <p className="text-red-500 text-sm">{errors.title}</p>}
          </div>

          <div>
            <label className="block text-sm font-medium text-zinc-700">Referência</label>
            <input
              type="text"
              name="reference"
              value={formData.reference}
              onChange={handleChange}
              className="w-full p-2 border rounded-md focus:ring-2 focus:ring-blue-500"
            />
            {errors.reference && <p className="text-red-500 text-sm">{errors.reference}</p>}
          </div>

          <div>
            <label className="block text-sm font-medium text-zinc-700">Conta</label>
            <input
              type="text"
              name="account"
              value={formData.account}
              onChange={handleChange}
              className="w-full p-2 border rounded-md focus:ring-2 focus:ring-blue-500"
            />
            {errors.account && <p className="text-red-500 text-sm">{errors.account}</p>}
          </div>
        </div>

        {/* Segunda linha: Senha e Data de Expiração */}
        <div className="grid grid-cols-2 gap-4">
          <div>
            <label className="block text-sm font-medium text-zinc-700">Senha</label>
            <input
              type="password"
              name="passwordValue"
              value={formData.passwordValue}
              onChange={handleChange}
              className="w-full p-2 border rounded-md focus:ring-2 focus:ring-blue-500"
            />
            {errors.passwordValue && <p className="text-red-500 text-sm">{errors.passwordValue}</p>}
          </div>

          <div>
            <label className="block text-sm font-medium text-zinc-700">Data de Expiração</label>
            <input
              type="date"
              name="expirationDate"
              value={formData.expirationDate}
              onChange={handleChange}
              className="w-full p-2 border rounded-md focus:ring-2 focus:ring-blue-500"
            />
            {errors.expirationDate && <p className="text-red-500 text-sm">{errors.expirationDate}</p>}
          </div>
        </div>

        {/* Descrição (linha única) */}
        <div>
          <label className="block text-sm font-medium text-zinc-700">Descrição</label>
          <textarea
            name="description"
            value={formData.description}
            onChange={handleChange}
            className="w-full p-2 border rounded-md focus:ring-2 focus:ring-blue-500"
          />
          {errors.description && <p className="text-red-500 text-sm">{errors.description}</p>}
        </div>

        {/* Checkbox - Administrador */}
        <div className="flex items-center">
          <input
            type="checkbox"
            name="isAdmin"
            checked={formData.isAdmin}
            onChange={handleChange}
            className="w-4 h-4 text-blue-500"
          />
          <label className="ml-2 text-sm text-zinc-700">Acesso de Administrador</label>
        </div>

        {/* Botão de Envio */}
        <button
          type="submit"
          disabled={loading}
          className="w-full bg-blue-500 text-white p-2 rounded-md hover:bg-blue-600 transition disabled:opacity-50"
        >
          {loading ? "Cadastrando..." : "Cadastrar"}
        </button>

        {/* Mensagem de Feedback */}
        {message && <p className="text-center text-sm mt-2">{message}</p>}
      </form>
    </div>
  );
};

export default Cadastrar;

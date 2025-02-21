import React from "react";
import { useNavigate } from "react-router-dom";
import AccountService from "./AccountService";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import logo from "../../assets/logo.png";

const Account = () => {
  const navigate = useNavigate();
  const { formData, handleChange, handleSubmit } = AccountService();

  return (
    <div className="flex items-center justify-center h-screen w-screen bg-white dark:bg-zinc-900">
      <ToastContainer />
      <form
        onSubmit={handleSubmit}
        className="bg-zinc-100 w-96 p-8 gap-4 rounded-md flex flex-col justify-center items-center"
      >
        <div className="flex mb-4 gap-2 text-3xl justify-center items-center">
          <img alt="logo" src={logo} width={44} />
          <span className="text-black font-logo">Lock Safe</span>
        </div>

        <h1 className="text-black font-bold text-2xl">Entre com sua conta</h1>

        <div className="w-full">
          <label className="text-black">Nome Completo</label>
          <input
            className="text-black h-10 w-full p-2 rounded"
            type="text"
            name="fullName"
            value={formData.fullName}
            onChange={handleChange}
            placeholder="Digite seu nome completo"
          />
        </div>

        <div className="w-full">
          <label className="text-black">Usuário</label>
          <input
            className="text-black h-10 w-full p-2 rounded"
            type="text"
            name="userName"
            value={formData.userName}
            onChange={handleChange}
            placeholder="Digite seu usuário"
          />
        </div>

        <div className="w-full">
          <label className="text-black">Email</label>
          <input
            className="text-black h-10 w-full p-2 rounded"
            type="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            placeholder="Digite seu email"
          />
        </div>

        <div className="w-full">
          <label className="text-black">Senha</label>
          <input
            className="text-black h-10 w-full p-2 rounded"
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            placeholder="Digite sua senha"
          />
        </div>

        <div className="w-full flex justify-between">
          <div className="flex gap-1">
            <input type="checkbox" />
            <label className="text-black">Lembrar-me</label>
          </div>
          <a href="/" className="text-sky-400">
            Recuperar senha
          </a>
        </div>

        <button
          type="submit"
          className="bg-sky-500 hover:bg-sky-400 outline-none focus:ring-sky-300 text-white h-10 w-full"
        >
          Cadastrar
        </button>

        <span className="text-black">
          Já possui conta?{" "}
          <a className="text-sky-400 cursor-pointer" onClick={() => navigate("/login")}>
            Faça login
          </a>
        </span>
      </form>
    </div>
  );
};

export default Account;

// src/views/Login.jsx
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import logo from "../../assets/logo.png";
import loginService from "./LoginService";

const Login = () => {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const user = await loginService.login(email, senha);
      // Redireciona para a tela inicial após login bem-sucedido
      navigate("/home");
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    
    <div className="flex items-center justify-center h-screen w-screen bg-white dark:bg-zinc-900">
      <div className="bg-zinc-100 w-96 p-8 gap-4 rounded-md flex flex-col justify-center items-center">
        <div className="flex mb-4 gap-2 text-3xl justify-center items-center">
          <img alt="logo" src={logo} width={44} />
          <span className="text-black font-logo">Lock Safe</span>
        </div>

        <h1 className="text-black font-bold text-2xl">Entre com sua conta</h1>

        {/* Mensagem de erro, caso ocorra */}
        {error && <div className="text-red-500">{error}</div>}

        <div className="w-full">
          <label className="text-black">Email</label>
          <input
            className="text-black h-10 w-full p-2 rounded"
            type="text"
            placeholder="Digite seu email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="w-full">
          <label className="text-black">Senha</label>
          <input
            className="text-black h-10 w-full p-2 rounded"
            type="password"
            placeholder="Digite sua senha"
            value={senha}
            onChange={(e) => setSenha(e.target.value)}
          />
        </div>

        <div className="w-full flex justify-between">
          <div className="flex gap-1">
            <input type="checkbox" />
            <label className="text-black">Lembrar-me</label>
          </div>
          <a href="/" className="text-sky-400">Recuperar senha</a>
        </div>
        <button
          className="bg-sky-500 hover:bg-sky-400 outline-none focus:ring-sky-300 text-white h-10 w-full"
          onClick={handleLogin}
        >
          Login
        </button>
        <span className="text-black">
          Não tem conta ?{" "}
          <a className="text-sky-400 cursor-pointer" onClick={() => navigate("/account")}>
            Cadastre-se
          </a>
        </span>
      </div>
    </div>
  );
};

export default Login;

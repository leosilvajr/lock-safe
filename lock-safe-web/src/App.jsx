// src/App.jsx
import React from "react";
import { Route, Routes } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Home from "./views/home/Home";
import Login from "./views/login/Login";
import Account from "./views/account/Account";
import Cadastrar from "./views/passwords/Cadastrar";
import Senhas from "./views/senhas/Senhas";

const App = () => {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/account" element={<Account />} />
      <Route element={<Sidebar />}>
        <Route path="/home" element={<Home />} />
        <Route path="/cadastrar" element={<Cadastrar />} />
        <Route path="/senhas" element={<Senhas />} />

      </Route>
      <Route path="/" element={<Login />} />
    </Routes>
  );
};
export default App;

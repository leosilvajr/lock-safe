import React, { useState, useEffect } from "react";
import SenhasService from "./SenhasService";
import { Pencil, Trash2, Eye, EyeOff } from "lucide-react";

const Senhas = () => {
  const [data, setData] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const recordsPerPage = 5;
  const [visiblePasswords, setVisiblePasswords] = useState({});

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await SenhasService();
        setData(result || []);
      } catch (error) {
        console.error("Erro ao buscar dados:", error);
        setData([]);
      }
    };

    fetchData();
  }, []);

  // Função para filtrar os dados com base na pesquisa
  const filteredData = data.filter(
    (record) =>
      record.Title.toLowerCase().includes(searchTerm.toLowerCase()) ||
      record.Description.toLowerCase().includes(searchTerm.toLowerCase()) ||
      record.Account.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const indexOfLastRecord = currentPage * recordsPerPage;
  const indexOfFirstRecord = indexOfLastRecord - recordsPerPage;
  const currentRecords = filteredData.slice(indexOfFirstRecord, indexOfLastRecord);
  const totalPages = Math.ceil(filteredData.length / recordsPerPage);

  const handleEdit = (index) => {
    console.log("Edit record at index:", index);
  };

  const handleDelete = (index) => {
    console.log("Delete record at index:", index);
  };

  const togglePasswordVisibility = (index) => {
    setVisiblePasswords((prev) => ({
      ...prev,
      [index]: !prev[index],
    }));
  };

  return (
    <div className="p-4">
      {/* Campo de busca */}
      <div className="mb-4">
        <input
          type="text"
          placeholder="Buscar por Título, Descrição ou Conta..."
          className="w-full p-2 border border-gray-300 rounded-md"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      {/* Tabela */}
      <table className="min-w-full border border-zinc-900"> 
        <thead>
          <tr className="bg-gray-100">
            <th className="px-4 py-3 border border-gray-300 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider w-[150px]">
              Título
            </th>
            <th className="px-4 py-3 border border-gray-300 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider w-[200px]">
              Descrição
            </th>
            <th className="px-4 py-3 border border-gray-300 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider w-[180px]">
              Conta
            </th>
            <th className="px-4 py-3 border border-gray-300 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider w-[160px]">
              Data de Expiração
            </th>
            <th className="px-4 py-3 border border-gray-300 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider w-[160px]">
              Senha
            </th>
            <th className="px-4 py-3 border border-gray-300 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider w-[100px]">
              Ações
            </th>
          </tr>
        </thead>
        <tbody>
          {currentRecords.length > 0 ? (
            currentRecords.map((record, index) => (
              <tr key={index} className="bg-white">
                <td className="px-4 py-3 border border-gray-300 text-sm">{record.Title}</td>
                <td className="px-4 py-3 border border-gray-300 text-sm">{record.Description}</td>
                <td className="px-4 py-3 border border-gray-300 text-sm">{record.Account}</td>
                <td className="px-4 py-3 border border-gray-300 text-sm">{record.ExpirationDate}</td>
                <td className="px-4 py-3 border border-gray-300 text-sm">
                  <div className="flex justify-between items-center w-full min-w-[120px]">
                    <span>{visiblePasswords[index] ? record.Password : "••••••••••••••••••••"}</span>
                    <button
                      onClick={() => togglePasswordVisibility(index)}
                      className="text-gray-600 hover:text-black"
                    >
                      {visiblePasswords[index] ? <EyeOff size={18} /> : <Eye size={18} />}
                    </button>
                  </div>
                </td>
                <td className="px-4 py-3 border border-gray-300 text-center text-sm">
                  <button onClick={() => handleEdit(index)} className="text-indigo-600 hover:text-indigo-900 mr-2">
                    <Pencil size={18} />
                  </button>
                  <button onClick={() => handleDelete(index)} className="text-red-600 hover:text-red-900">
                    <Trash2 size={18} />
                  </button>
                </td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="6" className="text-center py-4 text-gray-500">
                Nenhuma senha encontrada.
              </td>
            </tr>
          )}
        </tbody>
      </table>

      {/* Paginação */}
      {totalPages > 1 && (
        <div className="flex justify-center mt-4">
          <button
            onClick={() => setCurrentPage((prev) => Math.max(prev - 1, 1))}
            disabled={currentPage === 1}
            className="mr-2 p-2 bg-gray-200 text-sm disabled:opacity-50"
          >
            Anterior
          </button>
          <span className="p-2 text-sm">
            Página {currentPage} de {totalPages}
          </span>
          <button
            onClick={() => setCurrentPage((prev) => Math.min(prev + 1, totalPages))}
            disabled={currentPage === totalPages}
            className="ml-2 p-2 bg-gray-200 text-sm disabled:opacity-50"
          >
            Próximo
          </button>
        </div>
      )}
    </div>
  );
};

export default Senhas;

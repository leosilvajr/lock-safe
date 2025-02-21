import React, { useState } from "react";
import { Link, useLocation, Outlet } from "react-router-dom";
import { BiAddToQueue, BiExit, BiKey } from "react-icons/bi";
import { FaBell, FaSearch } from "react-icons/fa";
import { FaChevronDown, FaChevronRight, FaGears } from "react-icons/fa6";
import { FiTable } from "react-icons/fi";
import { MdOutlineHeadsetMic, MdSpaceDashboard } from "react-icons/md";
import { TiCalendar } from "react-icons/ti";
import { TbLayoutSidebarLeftCollapse, TbLayoutSidebarLeftExpand } from "react-icons/tb";
import logo from "../assets/logo.png";

const Sidebar = () => {
  const [open, setOpen] = useState(true);
  const [subMenus, setSubMenus] = useState({
    calendar: false,
    configuracoes: false,
    tables: false,
    analytics: false,
  });

  const location = useLocation();

  const toggleSubMenu = (menu) => {
    setSubMenus((prev) => ({
      ...prev,
      [menu]: !prev[menu],
    }));
  };

  const Menus = [
    { title: "Início", icon: <MdSpaceDashboard />, link: "/home" },
    { title: "Senhas", icon: <BiKey />, link: "/senhas" },
    { title: "Cadastrar", icon: <BiAddToQueue />, link: "/cadastrar" },
    { title: "Sair", icon: <BiExit />, link: "/login" },
  ];

  return (
    <div className="w-full flex">
      <div
        className={`${
          open ? "w-72 p-5" : "w-20 p-4"
        } bg-zinc-900 min-h-screen h-full pt-8 relative duration-300 ease-in-out bottom-0 left-0`}
      >
        <div
          className={`absolute cursor-pointer -right-4 top-9 w-8 h-8 p-0.5 bg-zinc-50 border-zinc-50 border-2 rounded-full text-xl flex items-center justify-center ${
            !open && "rotate-180"
          } transition-all ease-in-out duration-300`}
          onClick={() => setOpen(!open)}
        >
          {open ? <TbLayoutSidebarLeftExpand /> : <TbLayoutSidebarLeftCollapse />}
        </div>

        <div className="flex gap-x-4 items-center">
          <img
            src={logo}
            alt="logo"
            className={`w-12 h-12 rounded-full object-cover object-center cursor-pointer ease-in-out duration-3 ${
              open && "rotate-[360deg]"
            }`}
          />

          <h1
            className={`text-zinc-50 origin-left font-semibold text-xl duration-200 ease-in-out ${
              !open && "scale-0"
            }`}
          >
            Lock Safe
          </h1>
        </div>

        <ul className="pt-6 space-y-0.5">
          {Menus.map((Menu, index) => (
            <li
              key={index}
              className={`flex flex-col rounded-md py-3 px-4 cursor-pointer hover:text-white text-zinc-50 hover:bg-zinc-800/50 transition-all ease-in-out duration-300 ${
                Menu.gap ? "mt-9" : "mt-2"
              } ${location.pathname === Menu.link ? "bg-zinc-800/40" : ""}`}
            >
              <Link to={Menu.link}
                className="flex items-center justify-between gap-x-4"
                onClick={() => {
                  if (Menu.subMenu) toggleSubMenu(Menu.key);
                }}
              >
                <div className="flex items-center gap-2">
                  <span className="text-lg">{Menu.icon}</span>
                  <span
                    className={`${!open && "hidden"} origin-left ease-in-out duration-300`}
                  >
                    {Menu.title}
                  </span>
                </div>

                {Menu.subMenu && (
                  <span
                    className={`ml-auto cursor-pointer text-sm ${
                      subMenus[Menu.key] ? "rotate-360" : ""
                    } transition-transform ease-in-out duration-300 ${!open ? "hidden" : ""}`}
                  >
                    {subMenus[Menu.key] ? <FaChevronDown /> : <FaChevronRight />}
                  </span>
                )}
              </Link>

              {Menu.subMenu && subMenus[Menu.key] && (
                <ul className="pl-3 pt-4 text-zinc-300">
                  {Menu.subMenu.map((subMenu, subIndex) => (
                    <li
                      key={subIndex}
                      className="text-sm flex items-center gap-x-2 py-3 px-2 hover:bg-zinc-800 rounded-lg"
                    >
                      <Link to={subMenu.link} className="flex items-center gap-x-2">
                        <span className="text-zinc-4">
                          <FaChevronRight className="text-xs" />
                        </span>
                        {subMenu.title}
                      </Link>
                    </li>
                  ))}
                </ul>
              )}
            </li>
          ))}
        </ul>
      </div>

      <div className="w-full bg-zinc-100 space-y-6">
        <div className="w-full h-[8ch] px-12 bg-zinc-50 shadow-md flex items-center justify-between space-x-4">
          <div className="w-full max-w-96 border border-zinc-300 rounded-full h-11 flex items-center justify-center">
            <input
              type="text"
              placeholder="Pesquisar..."
              className="flex-1 h-full rounded-full outline-none border-none bg-zinc-50 px-4"
            />

            <button className="px-4 h-full flex items-center justify-center text-base text-zinc-600 border-l border-zinc-300">
              <FaSearch />
            </button>
          </div>

          <div className="flex items-center gap-x-8">
            <button className="relative">
              <div className="w-5 h-5 bg-zinc-50 flex items-center justify-center absolute -top-1.5 -right-2.5 rounded-full p-0.5">
                <span className="bg-red-600 text-white rounded-full w-full h-full flex items-center justify-center text-xs">
                  3
                </span>
              </div>
              <FaBell className="text-xl" />
            </button>

            <img
              src="https://avatars.githubusercontent.com/u/106756853?s=400&u=c25ea9d4b8b7b039dc98f9c04ee51792c4428349&v=4"
              alt="profile img"
              className="w-11 h-11 rounded-full object-cover object-center cursor-pointer"
            />
          </div>
        </div>

        <Outlet />
      </div>
    </div>
  );
};

export default Sidebar;
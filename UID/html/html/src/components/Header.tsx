"use client";
import * as React from "react";
import "./styles.css";
import burgerImg from '../photos/burger.png';
export function Header() {
  return (


    

    <header className="header-container px-1 py-2 normal:px-10">
      <div className="flex flex-wrap gap-4 items-center">
        <img
          src="https://cdn.builder.io/api/v1/image/assets/TEMP/eff079587dc7c016cd15bf6315c7602157ed3414?placeholderIfAbsent=true"
          className="object-contain shrink-0 self-stretch max-w-full rounded-md aspect-square normal:w-[100px] w-10 "
          alt="Logo"
        />
        <div className="search-container normal:min-w-96 flex justify-between normal:p-4 mobile:w-40 mobile:h-12 mobile:w-fit mobile:p-1">
          <div className="my-auto mobile:text-xs">Поиск по рецептам</div>
          <img
            src="https://cdn.builder.io/api/v1/image/assets/TEMP/00f95ba067632837618d2f20cd7f983afdc566e9?placeholderIfAbsent=true"
            className="object-contain shrink-0 aspect-square w-[35px]"
            alt="Search"
          />
        </div>
        <img
          src="https://cdn.builder.io/api/v1/image/assets/TEMP/343f41ee523a4bdb19ba400b3b3829a82f6038ed?placeholderIfAbsent=true"
          className="object-contain shrink-0 self-stretch my-auto rounded-none aspect-square w-[70px] block mobile:hidden"
          alt="Menu"
        />
        <img
            src="https://cdn.builder.io/api/v1/image/assets/TEMP/b0ef2d358f9bc959b59a69f5aa5fcd1ae4ee0e0e?placeholderIfAbsent=true"
            className="object-contain shrink-0 aspect-square w-[35px] normal:hidden"
            alt="Book"
          />
          <img src={burgerImg} alt="Burger menu" className="object-contain shrink-0 aspect-square w-[35px] hidden mobile:block"/>
      </div>
      
      <nav className="nav-container hidden normal:flex">
        <div className="self-stretch my-auto">Рецепты</div>
        <div className="divider" />
        <div className="flex gap-2.5 self-stretch my-auto">
          <img
            src="https://cdn.builder.io/api/v1/image/assets/TEMP/b0ef2d358f9bc959b59a69f5aa5fcd1ae4ee0e0e?placeholderIfAbsent=true"
            className="object-contain shrink-0 aspect-square w-[35px] "
            alt="Book"
          />
          <div className="my-auto basis-auto ">Моя книга</div>
        </div>
         <div className="flex gap-2 self-stretch my-auto whitespace-nowrap ">
          <img
            src="https://cdn.builder.io/api/v1/image/assets/TEMP/decb4732c701d0a093e8058331d27e6a60c7479f?placeholderIfAbsent=true"
            className="object-contain shrink-0 aspect-square w-[35px]"
            alt="Login"
          />
          <div className="my-auto">Войти</div>
        </div>
        <button className="add-recipe-button  px-14 py-6">Добавить рецепт</button>
      </nav>
    </header>
  );
}

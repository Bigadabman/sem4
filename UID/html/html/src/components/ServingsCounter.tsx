"use client";
import * as React from "react";
import "./styles.css";

export function ServingsCounter() {
  const [servings, setServings] = React.useState(0);

  const increment = () => setServings((prev) => prev + 1);
  const decrement = () => setServings((prev) => Math.max(0, prev - 1));

  return (
    <div className="w-[188px] flex flex-col">
      <h3 className="self-start text-2xl">Кол-во порций</h3>
      <div className="flex relative justify-center items-start mt-3.5 text-xl whitespace-nowrap">
        <button
          onClick={decrement}
          className="flex z-0 shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[62px] items-center justify-center hover:bg-zinc-200"
          style={{ cursor: "pointer" }}
        >
          -
        </button>
        <div className="flex z-0 shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[63px] items-center justify-center">
          {servings}
        </div>
        <button
          onClick={increment}
          className="flex z-0 shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[62px] items-center justify-center hover:bg-zinc-200"
          style={{ cursor: "pointer" }}
        >
          +
        </button>
      </div>
    </div>
  );
}

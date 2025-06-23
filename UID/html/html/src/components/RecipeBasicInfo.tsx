"use client";
import * as React from "react";

interface RecipeBasicInfoProps {
  recipeName: string;
  servings: number;
  hours: number;
  minutes: number;
  onRecipeNameChange: (name: string) => void;
  onServingsChange: (servings: number) => void;
  onHoursChange: (hours: number) => void;
  onMinutesChange: (minutes: number) => void;
}

export function RecipeBasicInfo({
  recipeName,
  servings,
  hours,
  minutes,
  onRecipeNameChange,
  onServingsChange,
  onHoursChange,
  onMinutesChange,
}: RecipeBasicInfoProps) {
  return (
    <div className="flex flex-col items-center max-w-full w-[775px]">
      <h1 className="max-w-full text-5xl font-bold text-black rounded-none w-[476px] max-md:max-w-full max-md:text-4xl">
        Добавление рецепта
      </h1>

      <div className="mt-12 w-full text-xl text-black whitespace-nowrap max-md:mt-10">
        <label className="block text-2xl">Название</label>
        <input  
          type="text"
          value={recipeName}
          onChange={(e) => onRecipeNameChange(e.target.value)}
          className="flex mt-1.5 w-full border border-solid bg-zinc-100 border-zinc-300 min-h-[50px] px-4"
        />
      </div>

      <div className="flex flex-wrap gap-10 justify-between items-start mt-12 w-full text-black max-w-[775px] min-h-[104px] max-md:mt-10 max-md:max-w-full">
        <div className="flex flex-col w-[188px]">
          <h3 className="self-start text-2xl">Кол-во порций</h3>
          <div className="flex relative justify-center items-start mt-3.5 text-xl whitespace-nowrap">
            <button
              onClick={() => onServingsChange(Math.max(0, servings - 1))}
              className="flex z-0 shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[62px] items-center justify-center"
            >
              -
            </button>
            <div className="flex z-0 shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[63px] items-center justify-center">
              {servings}
            </div>
            <button
              onClick={() => onServingsChange(servings + 1)}
              className="flex z-0 shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[62px] items-center justify-center"
            >
              +
            </button>
          </div>
        </div>

        <div className="flex gap-4 text-xl min-w-60 w-[377px]">
          <div className="flex flex-col grow shrink-0 basis-0 w-fit">
            <label className="self-start">Время приготовления</label>
            <div className="flex gap-5 mt-4 whitespace-nowrap">
              <input
                type="number"
                value={hours}
                onChange={(e) => onHoursChange(parseInt(e.target.value) || 0)}
                className="flex shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[100px] px-4"
              />
              <span className="my-auto">Часов</span>
              <input
                type="number"
                value={minutes}
                onChange={(e) => onMinutesChange(parseInt(e.target.value) || 0)}
                className="flex shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[100px] px-4"
              />
            </div>
          </div>
          <span className="self-end mt-16 max-md:mt-10">Минут</span>
        </div>
      </div>
    </div>
  );
}

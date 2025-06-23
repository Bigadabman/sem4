"use client";
import * as React from "react";

interface CategorySelectionProps {
  selectedCategory: string;
  selectedCuisine: string;
  onCategoryChange: (category: string) => void;
  onCuisineChange: (cuisine: string) => void;
}

export function CategorySelection({
  selectedCategory,
  selectedCuisine,
  onCategoryChange,
  onCuisineChange,
}: CategorySelectionProps) {
  return (
    <div className="flex flex-wrap gap-5 justify-center items-start mt-12 w-full min-h-[99px] max-md:mt-10">
      <div className="relative flex-1 shrink basis-0 h-[86px] min-w-60">
        <label className="z-0 text-xl text-black">Категория блюда</label>
        <select
          value={selectedCategory}
          onChange={(e) => onCategoryChange(e.target.value)}
          className="flex z-0 mt-3.5 w-full border border-solid bg-zinc-100 border-zinc-300 min-h-[62px] px-4 appearance-none opacity-50" 
        >
          <option value="">Выберите категорию</option>
          <option value="breakfast">Завтраки</option>
          <option value="lunch">Обеды</option>
          <option value="dinner">Ужины</option>
        </select>
        <img
          src="https://cdn.builder.io/api/v1/image/assets/TEMP/2833da59872fcecf13a9b6823ae8168c4b9b7a8e?placeholderIfAbsent=true&apiKey=e6ed756fd2034521b509efd3bf5efb2c"
          alt="Dropdown arrow"
          className="object-contain absolute z-0 w-7 h-7 aspect-[1.04] bottom-[5px] right-[23px] pointer-events-none"
        />
      </div>

      <div className="relative flex-1 shrink basis-0 min-w-60">
        <label className="z-0 text-xl text-black">Национальная кухня</label>
        <select
          value={selectedCuisine}
          onChange={(e) => onCuisineChange(e.target.value)}
          className="flex z-0 mt-3.5 w-full border border-solid bg-zinc-100 border-zinc-300 min-h-[62px] px-4 appearance-none text-gray-600"
        >
          <option value="" >Выберите кухню</option>
          <option value="russian">Русская</option>
          <option value="italian">Итальянская</option>
          <option value="asian">Азиатская</option>
        </select>
        <img
          src="https://cdn.builder.io/api/v1/image/assets/TEMP/4ed9f65cf89e1ba645639b39bbd19e6b81a919d2?placeholderIfAbsent=true&apiKey=e6ed756fd2034521b509efd3bf5efb2c"
          alt="Dropdown arrow"
          className="object-contain absolute z-0 w-7 h-7 aspect-[1.04] bottom-[18px] right-[19px] pointer-events-none"
        />
      </div>
    </div>
  );
}

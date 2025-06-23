"use client";
import * as React from "react";
import { ServingsCounter } from "./ServingsCounter";
import { TimeInput } from "./TimeInput";
import { PhotoUpload } from "./PhotoUpload";
import { CategorySelect } from "./CategorySelect";
import "./styles.css";

export function RecipeForm() {
  const [recipeName, setRecipeName] = React.useState("");

  const categoryOptions = [
    "Завтраки",
    "Обеды",
    "Ужины",
    "Десерты",
    "Закуски",
    "Супы",
  ];

  const cuisineOptions = [
    "Русская",
    "Итальянская",
    "Французская",
    "Китайская",
    "Японская",
    "Мексиканская",
  ];

  return (
    <main className="main-content py-10 mobile:p-4">
      <div className="form-section">
        <h1 className="section-title text-[3rem] mobile:text-[24px] w-fit w-full">Добавление рецепта</h1>

        <div className="input-group">
          <label>Название</label>
          <input
            type="text"
            value={recipeName}
            onChange={(e) => setRecipeName(e.target.value)}
            className="text-input"
            placeholder="Введите название рецепта"
          />
        </div>

        <div className="controls-row">
          <ServingsCounter />
          <TimeInput />
        </div>

        <PhotoUpload />

        <div className="flex flex-wrap gap-5 justify-center items-start mt-12 w-full min-h-[99px]">
          <CategorySelect
            label="Категория блюда"
            placeholder="Выберите категорию"
            options={categoryOptions}
          />
          <CategorySelect
            label="Национальная кухня"
            placeholder="Выберите кухню"
            options={cuisineOptions}
          />
        </div>
      </div>
    </main>
  );
}

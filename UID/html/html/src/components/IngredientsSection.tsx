"use client";
import * as React from "react";
import "./styles.css";

interface Ingredient {
  id: number;
  name: string;
  amount: string;
}

export function IngredientsSection() {
  const [ingredients, setIngredients] = React.useState<Ingredient[]>([
    { id: 1, name: "", amount: "0 гр" },
    { id: 2, name: "", amount: "0 гр" },
  ]);

  const addIngredient = () => {
    const newId = Math.max(...ingredients.map((i) => i.id)) + 1;
    setIngredients([...ingredients, { id: newId, name: "", amount: "0 гр" }]);
  };

  const updateIngredient = (
    id: number,
    field: "name" | "amount",
    value: string,
  ) => {
    setIngredients(
      ingredients.map((ing) =>
        ing.id === id ? { ...ing, [field]: value } : ing,
      ),
    );
  };

  return (
    <section className="flex flex-col items-center mt-12 w-full max-w-[775px] px-4 mobile:px-2 mx-auto">
      <h2 className="text-4xl font-bold text-black text-center mb-12">
        Ингредиенты
      </h2>

      <div className="flex flex-col w-full gap-5">
        {ingredients.map((ingredient, index) => (
          <div
            key={ingredient.id}
            className="flex flex-col mobile:flex-row gap-3 w-full items-start"
          >
            <div className="text-xl text-black mobile:w-32">
              Ингредиент {index + 1}
            </div>

            <div className="flex flex-1 gap-0 w-full items-center">
              <input
                type="text"
                value={ingredient.name}
                onChange={(e) =>
                  updateIngredient(ingredient.id, "name", e.target.value)
                }
                className="flex-1 border border-solid bg-zinc-100 border-zinc-300 h-16 p-4 rounded-md"
                placeholder="Название ингредиента"
              />

              <input
                type="text"
                value={ingredient.amount}
                onChange={(e) =>
                  updateIngredient(ingredient.id, "amount", e.target.value)
                }
                className="w-32 border border-solid bg-zinc-100 border-zinc-300 h-16 p-4 rounded-md text-center"
                placeholder="Количество"
              />
            </div>
          </div>
        ))}

        <button
          onClick={addIngredient}
          className="flex items-center justify-center mt-5 text-xl text-green-600 hover:text-green-700 w-full mobile:w-auto"
        >
          <img
            src="https://cdn.builder.io/api/v1/image/assets/TEMP/eda2ffdfac3187c17a9b4036315e63424708fea2?placeholderIfAbsent=true"
            className="w-7 h-7 mr-2"
            alt="Add"
          />
          <span>Добавить ингредиент</span>
        </button>
      </div>
    </section>
  );
}
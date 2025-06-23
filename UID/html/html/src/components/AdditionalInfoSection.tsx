"use client";
import * as React from "react";
import "./styles.css";

export function AdditionalInfoSection() {
  const [description, setDescription] = React.useState("");

  const handleClear = () => {
    setDescription("");
  };

  const handleSave = () => {
    console.log("Saving recipe...");
  };

  return (
    <section className="flex flex-col  text-xl w-full max-w-[776px] px-4 mobile:px-2">
      <h2 className="text-4xl font-bold text-black text-center mb-8">
        Дополнительная информация
      </h2>
      
      <div className="relative w-full">
        <label className="text-black">Описание</label>
        <textarea
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          className="w-full rounded-md border border-solid bg-zinc-100 border-zinc-300 min-h-[125px] p-4 resize-none mt-2"
          placeholder="Расскажите о своем рецепте"
        />
      </div>
      
      <div className="flex flex-row mobile:flex-row gap-2.5 mobile:gap-1.5 ml-[-8px] w-[100%] mobile:w-auto mobile:self-start mt-7">
        <button
          onClick={handleClear}
          className="rounded-md border-solid border-[3px] border-red-600 h-16 mobile:h-[63px] w-[90%] mobile:w-auto hover:bg-red-50 text-red-600 px-6 mobile:px-10"
        >
          Очистить
        </button>
        <button
          onClick={handleSave}
          className="bg-green-600 rounded-md h-16 mobile:h-[63px] w-[90%] mobile:w-auto hover:bg-green-700 text-white px-6 mobile:px-10"
        >
          Сохранить
        </button>
      </div>
    </section>
  );
}
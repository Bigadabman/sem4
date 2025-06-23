"use client";
import * as React from "react";

interface AdditionalInfoProps {
  description: string;
  onDescriptionChange: (description: string) => void;
  onClear: () => void;
  onSave: () => void;
}

export function AdditionalInfo({
  description,
  onDescriptionChange,
  onClear,
  onSave,
}: AdditionalInfoProps) {
  return (
    <div className="flex flex-col mt-12 max-w-full text-xl rounded-none w-[776px] max-md:mt-10">
      <h2 className="self-center text-4xl font-bold text-black max-md:max-w-full">
        Дополнительная информация
      </h2>

      <div className="relative mt-12 text-black max-md:mt-10 max-md:max-w-full">
        <label className="z-0 block">Описание</label>
        <textarea
          value={description}
          onChange={(e) => onDescriptionChange(e.target.value)}
          placeholder="Расскажите о своем рецепте"
          className="flex z-0 w-full rounded-md border border-solid bg-zinc-100 border-zinc-300 min-h-[125px] p-4 resize-none"
        />
      </div>

      <div className="flex gap-3.5 self-end mt-7 max-w-full whitespace-nowrap w-[374px]">
        <button
          onClick={onClear}
          className="gap-3.5 self-stretch px-10 py-5 text-red-600 rounded-md border-solid bg-green-600 bg-opacity-0 border-[3px] border-[color:var(--Myred,#DE322E)] min-h-[63px] max-md:px-5"
        >
          Очистить
        </button>
        <button
          onClick={onSave}
          className="gap-3.5 self-stretch py-5 pr-10 pl-9 text-white bg-green-600 rounded-md min-h-[63px] max-md:px-5"
        >
          Сохранить
        </button>
      </div>
    </div>
  );
}

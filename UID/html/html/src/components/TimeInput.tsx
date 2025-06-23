"use client";
import * as React from "react";
import "./styles.css";

export function TimeInput() {
  const [hours, setHours] = React.useState("");
  const [minutes, setMinutes] = React.useState("");

  return (
    <div className="flex gap-4 text-xl min-w-60 w-[377px]">
      <div className="flex flex-col grow shrink-0 basis-0 w-fit">
        <label className="self-start">Время приготовления</label>
        <div className="flex gap-2 mt-4 whitespace-nowrap">
          <input
            type="number"
            value={hours}
            onChange={(e) => setHours(e.target.value)}
            className="flex shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[100px] text-center"
            style={{ padding: "0 0.75rem" }}
            placeholder="0"
            min="0"
          />
          <div className="my-auto">Часов</div>
          <input
            type="number"
            value={minutes}
            onChange={(e) => setMinutes(e.target.value)}
            className="flex shrink-0 border border-solid bg-zinc-100 border-zinc-300 h-[63px] w-[100px] text-center"
            style={{ padding: "0 0.75rem" }}
            placeholder="0"
            min="0"
            max="59"
          />
          <div className="my-auto">Минут</div>
        </div>
      </div>
      
    </div>
  );
}

"use client";
import * as React from "react";
import "./styles.css";

interface CategorySelectProps {
  label: string;
  placeholder: string;
  options: string[];
}

export function CategorySelect({
  label,
  placeholder,
  options,
}: CategorySelectProps) {
  const [isOpen, setIsOpen] = React.useState(false);
  const [selected, setSelected] = React.useState("");

  const handleSelect = (option: string) => {
    setSelected(option);
    setIsOpen(false);
  };

  return (
    <div className="relative flex-1 shrink basis-0 min-w-60">
      <label className="text-xl text-black">{label}</label>
      <div className="relative mt-3.5">
        <button
          onClick={() => setIsOpen(!isOpen)}
          className="flex w-full border border-solid bg-zinc-100 border-zinc-300 min-h-[62px] items-center justify-between"
          style={{ padding: "0 1rem" }}
        >
          <span className="text-lg text-black opacity-50">{selected || placeholder}</span>
          <img
            src="https://cdn.builder.io/api/v1/image/assets/TEMP/2833da59872fcecf13a9b6823ae8168c4b9b7a8e?placeholderIfAbsent=true"
            className="object-contain w-7 h-7 aspect-[1.04]"
            alt="Dropdown arrow"
          />
        </button>
        {isOpen && (
          <div className="absolute top-full left-0 right-0 bg-white border border-zinc-300 border-t-0 z-20 max-h-48 overflow-y-auto">
            {options.map((option, index) => (
              <button
                key={index}
                onClick={() => handleSelect(option)}
                className="w-full text-left hover:bg-zinc-100 text-black"
                style={{ padding: "0.75rem 1rem" }}
              >
                {option}
              </button>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}

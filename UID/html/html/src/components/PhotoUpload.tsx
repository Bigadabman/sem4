"use client";
import * as React from "react";
import "./styles.css";

export function PhotoUpload() {
  const [selectedFile, setSelectedFile] = React.useState<File | null>(null);

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      setSelectedFile(file);
    }
  };

  return (
    <div className="flex flex-col mt-12 w-full text-xl text-black">
      <label className="self-start">Фото готового блюда</label>
      <div className="relative mt-3">
        <input
          type="file"
          accept="image/*"
          onChange={handleFileChange}
          className="absolute inset-0 w-full h-full opacity-0 cursor-pointer z-10"
        />
        <div
          className="bg-gray-200 border border-dashed border-zinc-600 text-center cursor-pointer hover:bg-gray-300 opacity-50" 
          style={{
            padding: "7rem 4rem 6rem 4rem",
          }}
        >
          {selectedFile ? selectedFile.name : "Добавить фото"}
        </div>
      </div>
    </div>
  );
}

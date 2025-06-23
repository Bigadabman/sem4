"use client";
import * as React from "react";
import "./styles.css";

interface Step {
  id: number;
  instruction: string;
}

export function InstructionsSection() {
  const [steps, setSteps] = React.useState<Step[]>([
    { id: 1, instruction: "" },
    { id: 2, instruction: "" },
  ]);

  const addStep = () => {
    const newId = Math.max(...steps.map((s) => s.id)) + 1;
    setSteps([...steps, { id: newId, instruction: "" }]);
  };

  const updateStep = (id: number, instruction: string) => {
    setSteps(
      steps.map((step) => (step.id === id ? { ...step, instruction } : step)),
    );
  };

  const removeStep = (id: number) => {
    if (steps.length > 1) {
      setSteps(steps.filter((step) => step.id !== id));
    }
  };

  return (
    <section className="flex flex-col mt-12 w-full max-w-[775px] px-4 mobile:px-2 mx-auto">\
      <h2 className="text-4xl font-bold text-black text-center mb-12 break-words">
        Пошаговая инструкция
      </h2>

      <div className="flex flex-col items-center w-full gap-5">
        {steps.map((step, index) => (
          <div
            key={step.id}
            className="flex flex-col w-full gap-2"
          >
            <h3 className="text-xl text-black">Шаг {index + 1}</h3>
            <div className="flex gap-3 w-full items-start">
              <textarea
                value={step.instruction}
                onChange={(e) => updateStep(step.id, e.target.value)}
                className="flex-1 rounded-md border border-solid bg-zinc-100 border-zinc-300 min-h-[125px] p-4 resize-none"
                placeholder="Опишите шаг приготовления..."
              />
              <button
                onClick={() => removeStep(step.id)}
                className={`shrink-0 w-7 h-7 mt-1 hover:opacity-70 ${steps.length <= 1 ? "opacity-50 cursor-not-allowed" : "cursor-pointer"}`}
                disabled={steps.length <= 1}
              >
                <img
                  src="https://cdn.builder.io/api/v1/image/assets/TEMP/35e890da1c545d2a0a3c6e200eac22213c489216?placeholderIfAbsent=true"
                  className="object-contain w-full h-full"
                  alt="Remove step"
                />
              </button>
            </div>
          </div>
        ))}

        <button
          onClick={addStep}
          className="flex items-center mt-5 text-xl text-green-600 hover:text-green-700"
        >
          <img
            src="https://cdn.builder.io/api/v1/image/assets/TEMP/80d6f0c8d76cd82588cbaadd73952acb7e13b970?placeholderIfAbsent=true"
            className="w-12 mr-2"
            alt="Add step"
          />
          <span>Добавить шаг</span>
        </button>
      </div>
    </section>
  );
}
"use client";
import * as React from "react";
import { Header } from "./Header";
import { RecipeForm } from "./RecipeForm";
import { IngredientsSection } from "./IngredientsSection";
import { InstructionsSection } from "./InstructionsSection";
import { AdditionalInfoSection } from "./AdditionalInfoSection";
import { Footer } from "./Footer";
import "./styles.css";

function AddRecipe() {
  return (
    <div className="add-recipe-container">
      <Header />
      <RecipeForm />
      <div className="content-divider" />
      <IngredientsSection />
      <div className="content-divider" />
      <InstructionsSection />
      <div className="content-divider" />
      <div className="flex flex-col justify-center items-center py-10 w-full bg-zinc-100">
        <AdditionalInfoSection />
      </div>
      <Footer />
    </div>
  );
}

export default AddRecipe;

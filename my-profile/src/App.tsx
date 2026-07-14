import { AboutSection } from './components/sections/AboutSection'
import { ContactSection } from './components/sections/ContactSection'
import { EducationSection } from './components/sections/EducationSection'
import { ExperienceSection } from './components/sections/ExperienceSection'
import { Footer } from './components/sections/Footer'
import { HeroSection } from './components/sections/HeroSection'
import { SkillsSection } from './components/sections/SkillsSection'
import { profile } from './data/profile'

function App() {
  return (
    <main className="min-h-screen bg-stone-100 text-stone-950">
      <HeroSection profile={profile} />
      <AboutSection profile={profile} />
      <SkillsSection profile={profile} />
      <ExperienceSection profile={profile} />
      <EducationSection profile={profile} />
      <ContactSection profile={profile} />
      <Footer name={profile.name} />
    </main>
  )
}

export default App
